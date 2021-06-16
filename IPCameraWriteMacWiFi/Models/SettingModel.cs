using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityPack.Validation;
using IPCameraWriteMacWiFi.Base;

namespace IPCameraWriteMacWiFi.Models {
    public class SettingModel : INotifyPropertyChanged {

        string _ont_ip;
        public string ontIP {
            get { return _ont_ip; }
            set {
                _ont_ip = value;
                OnPropertyChanged(nameof(ontIP));
            }
        }
        string _ont_user;
        public string ontUser {
            get { return _ont_user; }
            set {
                _ont_user = value;
                OnPropertyChanged(nameof(ontUser));
            }
        }
        string _ont_password;
        public string ontPassword {
            get { return _ont_password; }
            set {
                _ont_password = value;
                OnPropertyChanged(nameof(ontPassword));
            }
        }
        string _ip;
        public string ipAddress {
            get { return _ip; }
            set {
                _ip = value;
                OnPropertyChanged(nameof(ipAddress));
            }
        }
        string _telnet_user;
        public string telnetUser {
            get { return _telnet_user; }
            set {
                _telnet_user = value;
                OnPropertyChanged(nameof(telnetUser));
            }
        }
        string _telnet_password;
        public string telnetPassword {
            get { return _telnet_password; }
            set {
                _telnet_password = value;
                OnPropertyChanged(nameof(telnetPassword));
            }
        }
        string _fw_version;
        public string firmwareVersion {
            get { return _fw_version; }
            set {
                _fw_version = value;
                OnPropertyChanged(nameof(firmwareVersion));
            }
        }
        string _mac_header;
        public string macHeader {
            get { return _mac_header; }
            set {
                _mac_header = value;
                OnPropertyChanged(nameof(macHeader));
            }
        }
        string _mac_end_recommend;
        public string macEndRecommend {
            get { return _mac_end_recommend; }
            set {
                _mac_end_recommend = value;
                OnPropertyChanged(nameof(macEndRecommend));
            }
        }
        string _mac_start;
        public string macStart {
            get {
                if (myGlobal.myTesting != null) myGlobal.myTesting.RAM.macStart = _mac_start;
                return _mac_start; 
            }
            set {
                _mac_start = value;
                OnPropertyChanged(nameof(macStart));
                calMacEndRecommend();
                if (myGlobal.myTesting != null) myGlobal.myTesting.RAM.macStart = value;
            }
        }
        string _mac_end;
        public string macEnd {
            get {
                if (myGlobal.myTesting != null) myGlobal.myTesting.RAM.macEnd = _mac_end;
                return _mac_end; 
            }
            set {
                _mac_end = value;
                OnPropertyChanged(nameof(macEnd));
                calMacEndRecommend();
                if (myGlobal.myTesting != null) myGlobal.myTesting.RAM.macEnd = _mac_end;
            }
        }
        string _mac_step;
        public string macStep {
            get { return _mac_step; }
            set {
                _mac_step = value;
                OnPropertyChanged(nameof(macStep));
                calMacEndRecommend();
            }
        }

       

        public SettingModel() {
            ontIP = "192.168.1.1";
            ontUser = "admin";
            ontPassword = "VnT3ch@dm1n";

            ipAddress = "192.168.1.2";
            telnetUser = "root";
            telnetPassword = "rt123456";
            firmwareVersion = "6.0.33";

            macHeader = "D49AA0";
            macStart = "1";
            macEnd = "2";
            macStep = "1";
        }

        #region sub-function
        void calMacEndRecommend() {
            if (_mac_end != null && _mac_start != null && _mac_step != null) {
                int end, start, step;
                bool r = int.TryParse(_mac_end, out end); if (!r) goto END;
                r = int.TryParse(_mac_start, out start); if (!r) goto END;
                r = int.TryParse(_mac_step, out step); if (!r) goto END;
                int range = end - start; if (range <= 0) goto END;
                int diff  = range % step;
                if (diff == 0) goto END;
                macEndRecommend = $"(Giá trị khuyến nghị: {end - diff})";
                return;
            END:
                macEndRecommend = "";
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
