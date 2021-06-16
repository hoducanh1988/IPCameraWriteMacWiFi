using IPCameraWriteMacWiFi.Commands;
using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilityPack.IO;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class SettingViewModel {

        public SettingViewModel() {
            //load setting file
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setting.xml") == false) _sm = new SettingModel();
            else _sm = XmlHelper<SettingModel>.FromXmlFile(AppDomain.CurrentDomain.BaseDirectory + "setting.xml");

            SaveCommand = new SettingSaveCommand(this);
        }


        SettingModel _sm;
        public SettingModel SM {
            get => _sm;
        }

        //command
        public ICommand SaveCommand {
            get;
            private set;
        }
    }
}
