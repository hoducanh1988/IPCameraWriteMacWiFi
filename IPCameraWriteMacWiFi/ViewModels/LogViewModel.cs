using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IPCameraWriteMacWiFi.Commands;
using IPCameraWriteMacWiFi.Models;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class LogViewModel {

        public LogViewModel() {
            _lm = new LogModel();
            GoCommand = new LogGoCommand(this);
        }

        LogModel _lm;
        public LogModel LM {
            get => _lm;
        }

        //command
        public ICommand GoCommand {
            get;
            private set;
        }
    }
}
