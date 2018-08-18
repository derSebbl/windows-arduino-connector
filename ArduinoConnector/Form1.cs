using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Automation;
using System.IO;
using Newtonsoft.Json;

namespace ArduinoConnector {
    public partial class Form1 : Form {
        SerialHelper serialHelper;
        private Timer timer1;
        RichTextBoxAutoScrollHelper textBoxHelper;

        string configDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sebsoft", "ArduinoConnector", "config.json");

        public Form1() {
            InitializeComponent();
            Init();

            textBoxHelper = new RichTextBoxAutoScrollHelper(textBoxSerialData, checkBoxAutoScroll, (bool autoScrollState) => { checkBoxAutoScroll.Checked = autoScrollState; });

            checkBoxAutoScroll.Checked = textBoxHelper.AutoScroll;
            serialHelper.OnDataReceivedCallback += OnSerialDataReceived;
            serialHelper.OnUnexpectedDisconnectCallback += OnUnexpectedDisconnect;
        }

        public void OnUnexpectedDisconnect() {
            SetStatusText("Unexpected Disconnect");
            textBoxHelper.Append("Disconnected");
            SetButtonText(false);
        }

        public void OnSerialDataReceived(string text) {
            AppendToSerialDataTextBox(text);

            OnDataReceived(text);
        }

        int lastPotiState = 0;
        private void OnDataReceived(string text) {
            if (text == "Right") SendCustomKeystrokeRight();
            else if (text == "Left") SendCustomKeystrokeLeft();
        }

        public void AppendToSerialDataTextBox(string text) {
            textBoxHelper.Append(text);
        }

        public class ApplicationData{
            public string Port { get; set; }
            public int Baud { get; set; }
            public string TextKeystrokeRight { get; set; }
            public string TextKeystrokeLeft { get; set; }
        }

        public void Init() {
            serialHelper = new SerialHelper();

            FillPortCombobox();
            LoadApplicationData();


            buttonConnection.Focus();
        }

        private void buttonConnect_Click(object sender, EventArgs e) {
            buttonConnection.Enabled = false;
            if (!serialHelper.IsConnected) {
                SetStatusText("Connecting");
                if (Connect()) {
                    SetStatusText("Connected");
                    textBoxHelper.Append("Connected");
                }
            } else {
                serialHelper.Close();
                SetStatusText("Disconnected");
                textBoxHelper.Append("Disconnected");
            }

            SetButtonText(serialHelper.IsConnected);
            buttonConnection.Enabled = true;
        }

        private void SetButtonText(bool isConnected) {
            buttonConnection.Text = isConnected ? "Disconnect" : "Connect";
        }

        public void InitTimer() {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //AppendToSerialDataTextBox("Lorem");
            SendCustomKeystrokeLeft();
            timer1.Stop();
        }

        private void SaveApplicationData() {
            string portString = comboBoxSerialPort.SelectedItem != null ? comboBoxSerialPort.SelectedItem.ToString() : "";
            ApplicationData data = new ApplicationData {
                Port = portString,
                Baud = int.Parse(textBoxBaudRate.Text),
                TextKeystrokeLeft = textBoxKeystrokeLeft.Text,
                TextKeystrokeRight = textBoxKeystrokeRight.Text,
            };

            Directory.CreateDirectory(Path.GetDirectoryName(configDataPath));

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(configDataPath,JsonConvert.SerializeObject(data));
        }

        private bool LoadApplicationData() {
            if (File.Exists(configDataPath)){
                // read file into a string and deserialize JSON to a type
                ApplicationData data = JsonConvert.DeserializeObject<ApplicationData>(File.ReadAllText(configDataPath));

                textBoxKeystrokeLeft.Text = data.TextKeystrokeLeft;
                textBoxKeystrokeRight.Text = data.TextKeystrokeRight;

                textBoxBaudRate.Text = data.Baud.ToString();
                foreach (var item in comboBoxSerialPort.Items) {
                    if (item.ToString() == data.Port) {
                        comboBoxSerialPort.SelectedItem = item;
                        break;
                    }
                }
                return true;
            } else {
                return false;
            }
        }

        private bool Connect() {
            SaveApplicationData();

            var portName = comboBoxSerialPort.SelectedItem;
            if (portName == null) {
                SetStatusText("No port selected");
                return false;
            }

            var textBaudRate = textBoxBaudRate.Text;
            if (textBaudRate == string.Empty) {
                SetStatusText("BaudRate musn't be empty");
                return false;
            }

            int baudRate;
            try {
                baudRate = int.Parse(textBaudRate);
            } catch {
                SetStatusText("Couldn't read baudrate field");
                return false;
            }

            try {
                serialHelper.Open(portName.ToString(), baudRate);
            } catch (Exception e) {
                SetStatusText(e.Message);
                return false;
            }

            return true;
        }

        private void SetStatusText(string text) {
            labelStatus.Text = text;
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            FillPortCombobox();
        }

        public void FillPortCombobox() {
            comboBoxSerialPort.Items.Clear();
            foreach (var item in serialHelper.GetPortNames()) {
                comboBoxSerialPort.Items.Add(item);
            }
        }

        private void checkBoxAutoScroll_CheckedChanged(object sender, EventArgs e) {
            textBoxHelper.AutoScroll = checkBoxAutoScroll.Checked;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;

        IntPtr chromePointer = IntPtr.Zero;
        IntPtr thisWindow;

        private void button1_Click(object sender, EventArgs e) {
            textBoxHelper.Clear();
        }

        private void button2_Click(object sender, EventArgs e) {
            InitTimer();
        }

        private void SendCustomKeystrokeLeft() {
            SendKeys.Send(textBoxKeystrokeLeft.Text);
        }
        private void SendCustomKeystrokeRight() {
            SendKeys.Send(textBoxKeystrokeRight.Text);
        }

        private void SendAltArrow(bool forward) {
            SendKeys.Send(forward ? "%({RIGHT})" : "%({LEFT})");
        }

        private void ScrollTab(bool backwards) {
            SetForegroundWindow(chromePointer);
            SendKeys.Send(backwards ? "^(+({TAB}))" : "^({TAB})");
            SetForegroundWindow(thisWindow);
        }

        private void InitialiseWindowPointers() {
            thisWindow = GetForegroundWindow();
            List<Process> processes = new List<Process>(Process.GetProcessesByName("chrome"));

            chromePointer = processes.Find(x => x.MainWindowHandle != IntPtr.Zero).MainWindowHandle;
        }

        private void OnControlStatusUpdated() {
            // to find the tabs we first need to locate something reliable - the 'New Tab' button 
            AutomationElement root = AutomationElement.FromHandle(chromePointer);
            Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "Neuer Tab");
            AutomationElement elmNewTab = root.FindFirst(TreeScope.Descendants, condNewTab);
            // get the tabstrip by getting the parent of the 'new tab' button 
            TreeWalker treewalker = TreeWalker.ControlViewWalker;
            AutomationElement elmTabStrip = treewalker.GetParent(elmNewTab);
            // loop through all the tabs and get the names which is the page title 
            Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
            var tabs = elmTabStrip.FindAll(TreeScope.Children, condTabItem);
            foreach (AutomationElement tabitem in tabs) {
                Console.WriteLine(tabitem.Current.Name);
            }

            Debug.WriteLine("Number of tabs open: " + tabs.Count);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            serialHelper.Close();
            SaveApplicationData();
        }
    }
}
