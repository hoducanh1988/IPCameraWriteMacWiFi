using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Models {
    public class MainWindowModel : INotifyPropertyChanged {

        string _product_name;
        public string productName {
            get { return _product_name; }
            set {
                _product_name = value;
                OnPropertyChanged(nameof(productName));
            }
        }
        string _app_info;
        public string appInfo {
            get { return _app_info; }
            set {
                _app_info = value;
                OnPropertyChanged(nameof(appInfo));
            }
        }
        string _station_name;
        public string stationName {
            get { return _station_name; }
            set {
                _station_name = value;
                OnPropertyChanged(nameof(stationName));
            }
        }

        public MainWindowModel() {
            productName = "Product: OEM IP CAMERA";
            stationName = "Station: Write Wifi MAC Address Via Telnet";
            appInfo = "Version: OEMCAMVN0U0001 - Build time: 10/06/2021 10:40 - Copyright of VNPT Technology 2021";
        }
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
