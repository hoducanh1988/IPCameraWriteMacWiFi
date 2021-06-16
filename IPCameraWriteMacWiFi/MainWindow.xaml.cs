using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.Views;
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
using System.Threading;

namespace IPCameraWriteMacWiFi {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        AboutView abv = new AboutView();
        HelpView hpv = new HelpView();
        LogView lgv = new LogView();
        SettingView stv = new SettingView();
        RunAllView rav = new RunAllView();
        CancellationTokenSource tokenSource2;

        public MainWindow() {
            InitializeComponent();
            this.DataContext = myGlobal.MainViewModel;
            myGlobal.MainViewModel.loadTabControl(this.sp_controller);

            Thread za = new Thread(new ThreadStart(() => {
                int c = 0;
            STA:
                Thread.Sleep(1000);
                bool r = Support.pingToHost(myGlobal.mySetting.SM.ontIP);
                if (!r) { c = 0; goto STA; }
                else {
                    c++;
                    if (c < 3) goto STA;
                }

                OntEconet ont = new OntEconet();
                r = ont.Login();
                if (!r) goto STA;
                r = ont.resetDhcp();
                if (!r) goto STA;

                ont.Close();
            }));
            za.IsBackground = true;
            za.Start();

            tokenSource2 = new CancellationTokenSource();
            CancellationToken ct = tokenSource2.Token;
            Task t = new Task(() => {
                ct.ThrowIfCancellationRequested();
            RE:
                foreach (var item in myGlobal.MainViewModel.listHeaderModel) {
                    if (item.THM.isClicked == true) {
                        var c = GetControlByHeader(item.THM.Header);
                        Dispatcher.Invoke(new Action(() => {
                            if (this.grid_main.Children.Contains(c) == false) {
                                this.grid_main.Children.Clear();
                                this.grid_main.Children.Add(c);
                            }
                        }));
                    }
                }
                Thread.Sleep(250);
                goto RE;

            }, tokenSource2.Token);
            t.Start();
        }

        private UserControl GetControlByHeader(string header) {
            switch (header) {
                case "RUN ALL": return rav;
                case "SETTING": return stv;
                case "LOG": return lgv;
                case "HELP": return hpv;
                case "ABOUT": return abv;
                default: return null;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            tokenSource2.Cancel();
            tokenSource2.Dispose();
        }
    }
}
