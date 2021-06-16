using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IPCameraWriteMacWiFi.Commands {
    public class RunAllSearchLogTelnetCommand : ICommand {

        private RunAllViewModel _ravm;
        public RunAllSearchLogTelnetCommand(RunAllViewModel ravm) {
            _ravm = ravm;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //enable button save setting
        public bool CanExecute(object parameter) {
            return true;
        }

        //save setting
        public void Execute(object parameter) {
            Database db = new Database();
            string data = db.getLogTelnetByUID(_ravm.RAM.telnetUID);
            _ravm.RAM.logTelnet = data;
            db.Close();
            System.Windows.MessageBox.Show("Sucess!", "Search Log Telnet", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        #endregion

    }
}
