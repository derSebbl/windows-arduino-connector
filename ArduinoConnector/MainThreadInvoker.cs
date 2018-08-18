using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoConnector {
    class MainThreadInvoker {

        System.Windows.Threading.Dispatcher mainThreadDispatcher;
        public MainThreadInvoker(System.Windows.Threading.Dispatcher mainThreadDispatcher) {
            this.mainThreadDispatcher = mainThreadDispatcher;
        }

        public void InvokeOnMainThread(Action act) {
            mainThreadDispatcher.BeginInvoke(act);
        }
    }
}
