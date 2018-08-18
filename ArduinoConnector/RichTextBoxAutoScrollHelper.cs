using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoConnector {
    class RichTextBoxAutoScrollHelper {
        public bool AutoScroll {
            get;
            set;
        }

        bool isCurrentlyInteracting = false;
        string cachedTextboxText;

        private Action<bool> OnAutoScrollChangedDelegate;

        RichTextBox textBoxSerialData;
        Control secondaryControlForTemporalFocus;
        public RichTextBoxAutoScrollHelper(RichTextBox box, Control secondaryControlForTemporalFocus, Action<bool> OnAutoScrollChangedDelegate = null) {
            AutoScroll = true;
            this.textBoxSerialData = box;
            this.secondaryControlForTemporalFocus = secondaryControlForTemporalFocus;
            this.OnAutoScrollChangedDelegate = OnAutoScrollChangedDelegate;

            textBoxSerialData.MouseDown += textBoxSerialData_MouseDown;
            textBoxSerialData.MouseUp += textBoxSerialData_MouseUp;
        }

        public void Append(string _text) {
            var dateTimeNow = DateTime.Now.ToString("HH:mm:ss.fff");
            string text = ">> " + dateTimeNow + " " + _text + Environment.NewLine;

            if (isCurrentlyInteracting) {
                cachedTextboxText += text;
                return;
            }

            RawAppend(text);
        }

        private void RawAppend(string text) {
            if (textBoxSerialData.Focused) {
                if (AutoScroll) {
                    HideSelection(false);

                    textBoxSerialData.AppendText(text);
                } else { //this is the problem case ....
                    HideCaret(textBoxSerialData.Handle);
                    secondaryControlForTemporalFocus.Focus();
                    HideSelection(true);
                    int pos = textBoxSerialData.SelectionStart;
                    int len = textBoxSerialData.SelectionLength;
                    textBoxSerialData.AppendText(text);
                    textBoxSerialData.SelectionStart = pos;
                    textBoxSerialData.SelectionLength = len;
                    HideSelection(false);
                    textBoxSerialData.Focus();
                }
            } else {
                if (AutoScroll) {
                    HideSelection(false);
                    textBoxSerialData.AppendText(text);
                } else {
                    HideSelection(true);
                    int pos = textBoxSerialData.SelectionStart;
                    textBoxSerialData.AppendText(text);
                    textBoxSerialData.SelectionStart = pos;
                }
            }
        }

        private void textBoxSerialData_MouseDown(object sender, MouseEventArgs e) {
            isCurrentlyInteracting = true;
        }

        private void textBoxSerialData_MouseUp(object sender, MouseEventArgs e) {
            if (!isCurrentlyInteracting) return;
            isCurrentlyInteracting = false;
            AutoScroll = false;
            OnAutoScrollChangedDelegate?.Invoke(AutoScroll);

            if (cachedTextboxText != string.Empty && cachedTextboxText != null) {
                RawAppend(cachedTextboxText);
                cachedTextboxText = null;
            }
        }


        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        const int WM_USER = 0x400;
        const int EM_HIDESELECTION = WM_USER + 63;
        public void HideSelection(bool hide) {
            SendMessage(textBoxSerialData.Handle, EM_HIDESELECTION, hide ? 1 : 0, 0);
        }

        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

        internal void Clear() {
            textBoxSerialData.Clear();
            RawAppend("");
        }
    }
}
