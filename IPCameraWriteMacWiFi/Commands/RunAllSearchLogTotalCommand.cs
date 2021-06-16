using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IPCameraWriteMacWiFi.Commands {
    public class RunAllSearchLogTotalCommand : ICommand {

        private RunAllViewModel _ravm;
        public RunAllSearchLogTotalCommand(RunAllViewModel ravm) {
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
            var data = db.getLogTotalByUID(_ravm.RAM.totalUID);
            db.Close();
            _ravm.collectionTotal.Clear();
            if (data != null && data.Count > 0) {
                foreach (var item in data) {
                    _ravm.collectionTotal.Add(item);
                }
            }
            System.Windows.MessageBox.Show("Sucess!", "Search Log Total", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        #endregion

    }
}
