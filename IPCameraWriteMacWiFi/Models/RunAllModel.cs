using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Models {
    public class RunAllModel : INotifyPropertyChanged {

        string _log_system;
        public string logSystem {
            get { return _log_system; }
            set {
                _log_system = value;
                OnPropertyChanged(nameof(logSystem));
            }
        }
        string _log_telnet;
        public string logTelnet {
            get { return _log_telnet; }
            set {
                _log_telnet = value;
                OnPropertyChanged(nameof(logTelnet));
            }
        }
        string _button_content;
        public string buttonContent {
            get { return _button_content; }
            set {
                _button_content = value;
                OnPropertyChanged(nameof(buttonContent));
            }
        }
        string _total_time;
        public string totalTime {
            get { return _total_time; }
            set {
                _total_time = value;
                OnPropertyChanged(nameof(totalTime));
            }
        }
        string _total_result;
        public string totalResult {
            get { return _total_result; }
            set {
                _total_result = value;
                OnPropertyChanged(nameof(totalResult));
            }
        }
        string _uid;
        public string UID {
            get { return _uid; }
            set {
                _uid = value;
                OnPropertyChanged(nameof(UID));
            }
        }
        string _mac_address;
        public string macAddress {
            get { return _mac_address; }
            set {
                _mac_address = value;
                OnPropertyChanged(nameof(macAddress));
            }
        }
        string _instruction_text;
        public string instructionText {
            get { return _instruction_text; }
            set {
                _instruction_text = value;
                OnPropertyChanged(nameof(instructionText));
            }
        }
        bool _is_testing;
        public bool isTesting {
            get { return _is_testing; }
            set {
                _is_testing = value;
                OnPropertyChanged(nameof(isTesting));
            }
        }

        string _system_uid;
        public string systemUID {
            get { return _system_uid; }
            set {
                _system_uid = value;
                OnPropertyChanged(nameof(systemUID));
            }
        }
        string _telnet_uid;
        public string telnetUID {
            get { return _telnet_uid; }
            set {
                _telnet_uid = value;
                OnPropertyChanged(nameof(telnetUID));
            }
        }
        string _total_uid;
        public string totalUID {
            get { return _total_uid; }
            set {
                _total_uid = value;
                OnPropertyChanged(nameof(totalUID));
            }
        }
        string _mac_uid;
        public string macUID {
            get { return _mac_uid; }
            set {
                _mac_uid = value;
                OnPropertyChanged(nameof(macUID));
            }
        }

        string _mac_start;
        public string macStart {
            get { return _mac_start; }
            set {
                _mac_start = value;
                OnPropertyChanged(nameof(macStart));
            }
        }
        string _mac_end;
        public string macEnd {
            get { return _mac_end; }
            set {
                _mac_end = value;
                OnPropertyChanged(nameof(macEnd));
            }
        }
        string _mac_remain;
        public string macRemain {
            get { return _mac_remain; }
            set {
                _mac_remain = value;
                OnPropertyChanged(nameof(macRemain));
            }
        }
        string _mac_current;
        public string macCurrent {
            get { return _mac_current; }
            set {
                _mac_current = value;
                OnPropertyChanged(nameof(macCurrent));
            }
        }

        public RunAllModel() {
            Init();
            buttonContent = "Start";
            instructionText = "Vui lòng nhấn nút Start.";
        }

        public void Init() {
            logSystem = "";
            logTelnet = "";
            totalTime = "00:00:00";
            totalResult = UID = macAddress = "-";
            isTesting = false;
            instructionText = "";
            systemUID = "";
            telnetUID = "";
            totalUID = "";
            macUID = "";
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public class ItemResult : INotifyPropertyChanged {

            string _name;
            public string Name {
                get { return _name; }
                set {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
            string _value;
            public string Value {
                get { return _value; }
                set {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
            string _result;
            public string Result {
                get { return _result; }
                set {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
            string _total_time;
            public string totalTime {
                get { return _total_time; }
                set {
                    _total_time = value;
                    OnPropertyChanged(nameof(totalTime));
                }
            }

            public ItemResult() {
                Name = Value = Result = totalTime = "";
            }

            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName) {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        public class FreeMacAddress : INotifyPropertyChanged {

            string _mac_address;
            public string macAddress {
                get { return _mac_address; }
                set {
                    _mac_address = value;
                    OnPropertyChanged(nameof(macAddress));
                }
            }

            string _mac_dec;
            public string  macDEC {
                get { return _mac_dec; }
                set {
                    _mac_dec = value;
                    OnPropertyChanged(nameof(macDEC));
                }
            }

            public FreeMacAddress() {
                macAddress = macDEC = "";
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
}
