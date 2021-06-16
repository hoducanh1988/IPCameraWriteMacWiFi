using IPCameraWriteMacWiFi.Models;
using IPCameraWriteMacWiFi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class MainWindowViewModel {
        
        public MainWindowViewModel() {
            _mwm = new MainWindowModel();
        }


        MainWindowModel _mwm;
        public MainWindowModel MainModel {
            get => _mwm;
        }

        #region load tab item
        public List<TabHeaderViewModel> listHeaderModel;
        public bool loadTabControl(StackPanel sp) {
            try {
                sp.Children.Clear();
                listHeaderModel = new List<TabHeaderViewModel>();
                List<string> listHeader = new List<string>() { "RUN ALL", "SETTING", "LOG", "HELP", "ABOUT" };
                foreach (var h in listHeader) {
                    TabHeaderViewModel thvm = new TabHeaderViewModel();
                    thvm.THM.Header = h;
                    TabHeaderView thv = new TabHeaderView(thvm);
                    sp.Children.Add(thv);
                    listHeaderModel.Add(thvm);
                }
                
                return true;
            } catch { return false; }
        }

        #endregion

    }
}
