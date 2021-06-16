using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IPCameraWriteMacWiFi.Commands {
    public class RunAllSearchLogMacCommand : ICommand {

        private RunAllViewModel _ravm;
        public RunAllSearchLogMacCommand(RunAllViewModel ravm) {
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
            var data = db.getLogWritedByUID(_ravm.RAM.macUID);
            db.Close();
            _ravm.collectionWrited.Clear();
            if (data != null && data.Count > 0) {
                foreach (var item in data) {
                    _ravm.collectionWrited.Add(item);
                }
            }
            System.Windows.MessageBox.Show("Sucess!", "Search Mac Writed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        #endregion

    }
}
