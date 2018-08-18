using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoConnector
{
    class SerialHelper
    {
        SerialPort serialPort;
        volatile bool shouldContinue;
        Thread readThread;

        MainThreadInvoker mainThreadInvoker;

        bool removeNewLine = true;

        public Action<string> OnDataReceivedCallback = null;
        public Action OnUnexpectedDisconnectCallback = null;

        public bool IsConnected {
            get { return shouldContinue; }
        }

        public SerialHelper()
        {
            serialPort = new SerialPort();
            mainThreadInvoker = new MainThreadInvoker(System.Windows.Threading.Dispatcher.CurrentDispatcher);
        }

        public void Open(string portName, int baudRate, int readTimeout = 500, int writeTimeout = 500, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One, Handshake handshake = Handshake.None)
        {
            readThread = new Thread(this.Read);

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.Parity = parity;
            serialPort.DataBits = dataBits;
            serialPort.StopBits = stopBits;
            serialPort.Handshake = handshake;

            serialPort.ReadTimeout = readTimeout;
            serialPort.WriteTimeout = writeTimeout;
            serialPort.Open();
            shouldContinue = true;

            readThread.Start();
        }

        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        private void Read()
        {
            while (shouldContinue)
            {
                try {
                    string message = serialPort.ReadLine();
                    if (removeNewLine && message.EndsWith("\r")) {
                        message = message.Substring(0, message.Length - 1);
                    }
                    mainThreadInvoker.InvokeOnMainThread(() => { OnDataReceived(message); });
                } catch (TimeoutException) { } 
                catch (System.InvalidOperationException) { } 
                catch {
                    mainThreadInvoker.InvokeOnMainThread(() => { OnUnexpectedDisconnect(); });
                }
            }
        }

        public void OnUnexpectedDisconnect() {
            Close();
            OnUnexpectedDisconnectCallback?.Invoke();
        }

        public void OnDataReceived(string data) {
            OnDataReceivedCallback?.Invoke(data);
        }

        public void Write(string str)
        {
            serialPort.Write(str);
        }

        public void Write(byte[] buffer, int offset = 0, int count = -1)
        {
            if (count == -1) count = buffer.Length;
            serialPort.Write(buffer, offset, count);
        }

        public void Close()
        {
            if (!shouldContinue) return; //already closed or not running at all

            shouldContinue = false;
            readThread.Join();
            serialPort.Close();
            Debug.WriteLine("Connection closed");
        }
    }
}
