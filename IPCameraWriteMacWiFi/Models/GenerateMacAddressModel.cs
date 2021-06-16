using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Models {
    public class GenerateMacAddressModel : INotifyPropertyChanged {

        int _pg_value;
        public int pgValue {
            get { return _pg_value; }
            set {
                _pg_value = value;
                OnPropertyChanged(nameof(pgValue));
                pgText = $"{value} / {pgMax}";
            }
        }
        int _pg_max;
        public int pgMax {
            get { return _pg_max; }
            set {
                _pg_max = value;
                OnPropertyChanged(nameof(pgMax));
                pgText = $"{pgValue} / {value}";
            }
        }
        string _pg_text;
        public string pgText {
            get { return _pg_text; }
            set {
                _pg_text = value;
                OnPropertyChanged(nameof(pgText));
            }
        }


        public GenerateMacAddressModel() {
            pgValue = 0;
            pgMax = 1;
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
