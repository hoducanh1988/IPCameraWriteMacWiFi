using IPCameraWriteMacWiFi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Base {
    public class myGlobal {

        public static MainWindowViewModel MainViewModel = new MainWindowViewModel();
        public static SettingViewModel mySetting = new SettingViewModel();
        public static RunAllViewModel myTesting = new RunAllViewModel();
        public static GenerateMacAddressViewModel myGenerate = new GenerateMacAddressViewModel();

    }
}
