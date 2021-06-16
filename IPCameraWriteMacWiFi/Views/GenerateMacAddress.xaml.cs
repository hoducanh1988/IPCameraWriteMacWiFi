using IPCameraWriteMacWiFi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IPCameraWriteMacWiFi.ViewModels;

namespace IPCameraWriteMacWiFi.Views {
    /// <summary>
    /// Interaction logic for GenerateMacAddress.xaml
    /// </summary>
    public partial class GenerateMacAddress : Window {
        public GenerateMacAddress() {
            InitializeComponent();
            myGlobal.myGenerate.GMAM.pgValue = 0;
            myGlobal.myGenerate.GMAM.pgMax = 0;

            this.DataContext = myGlobal.myGenerate;

            Thread t = new Thread(new ThreadStart(() => {
                Thread.Sleep(1000);
                Support.genMacAddress();
                Thread.Sleep(1000);
                Dispatcher.Invoke(new Action(() => { this.Close(); }));
            }));
            t.Start();
        }
    }
}
