using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Models {
    public class TabHeaderModel : INotifyPropertyChanged {

        string _header;
        public string Header {
            get { return _header; }
            set {
                _header = value;
                OnPropertyChanged(nameof(Header));
            }
        }
        bool _is_clicked;
        public bool isClicked {
            get { return _is_clicked; }
            set {
                _is_clicked = value;
                OnPropertyChanged(nameof(isClicked));
            }
        }


        public TabHeaderModel() {
            Header = "";
            isClicked = false;
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
