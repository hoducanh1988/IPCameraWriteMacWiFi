using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IPCameraWriteMacWiFi.Views {
    /// <summary>
    /// Interaction logic for TabHeaderView.xaml
    /// </summary>
    public partial class TabHeaderView : UserControl {

        public TabHeaderViewModel thvm;
        public TabHeaderView(TabHeaderViewModel _thvm) {
            InitializeComponent();
            thvm = _thvm;
            this.DataContext = thvm;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                foreach (var item in myGlobal.MainViewModel.listHeaderModel) item.THM.isClicked = false;
                thvm.THM.isClicked = true;
            }
        }
    }
}
