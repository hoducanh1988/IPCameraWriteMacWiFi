using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Base {
    public class Database {

        public class logTotalItem : INotifyPropertyChanged {
            int _id;
            public int ID {
                get { return _id; }
                set {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
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
            string _mac;
            public string Mac {
                get { return _mac; }
                set {
                    _mac = value;
                    OnPropertyChanged(nameof(Mac));
                }
            }
            string _login;
            public string Login {
                get { return _login; }
                set {
                    _login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
            string _get_fw;
            public string GetFirmware {
                get { return _get_fw; }
                set {
                    _get_fw = value;
                    OnPropertyChanged(nameof(GetFirmware));
                }
            }
            string _get_uid;
            public string GetUID {
                get { return _get_uid; }
                set {
                    _get_uid = value;
                    OnPropertyChanged(nameof(GetUID));
                }
            }
            string _get_mac;
            public string GetMac {
                get { return _get_mac; }
                set {
                    _get_mac = value;
                    OnPropertyChanged(nameof(GetMac));
                }
            }
            string _set_mac;
            public string SetMac {
                get { return _set_mac; }
                set {
                    _set_mac = value;
                    OnPropertyChanged(nameof(SetMac));
                }
            }
            string _verify_mac;
            public string VerifyMac {
                get { return _verify_mac; }
                set {
                    _verify_mac = value;
                    OnPropertyChanged(nameof(VerifyMac));
                }
            }
            string _total_time;
            public string TotalTime {
                get { return _total_time; }
                set {
                    _total_time = value;
                    OnPropertyChanged(nameof(TotalTime));
                }
            }
            string _total_result;
            public string TotalResult {
                get { return _total_result; }
                set {
                    _total_result = value;
                    OnPropertyChanged(nameof(TotalResult));
                }
            }
            string _date_time_created;
            public string DateTimeCreated {
                get { return _date_time_created; }
                set {
                    _date_time_created = value;
                    OnPropertyChanged(nameof(DateTimeCreated));
                }
            }

            public logTotalItem() {
                ID = 0;
                UID = Mac = Login = GetFirmware = GetUID = GetMac = SetMac = VerifyMac = TotalTime = TotalResult = DateTimeCreated = "";
            }


            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName) {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        class logSystemItem {
            public int ID { get; set; }
            public string UID { get; set; }
            public string Mac { get; set; }
            public string Content { get; set; }
            public string TotalResult { get; set; }
            public string DateTimeCreated { get; set; }
        }

        class logTelnetItem {
            public int ID { get; set; }
            public string UID { get; set; }
            public string Mac { get; set; }
            public string Content { get; set; }
            public string TotalResult { get; set; }
            public string DateTimeCreated { get; set; }
        }

        public class logMacWritedItem : INotifyPropertyChanged {
            int _id;
            public int ID {
                get { return _id; }
                set {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
            string _mac;
            public string Mac {
                get { return _mac; }
                set {
                    _mac = value;
                    OnPropertyChanged(nameof(Mac));
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
            string _date_time_writed;
            public string DateTimeWrited {
                get { return _date_time_writed; }
                set {
                    _date_time_writed = value;
                    OnPropertyChanged(nameof(DateTimeWrited));
                }
            }

            public logMacWritedItem() {
                ID = 0;
                Mac = UID = DateTimeWrited = "";
            }

            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName) {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        public class logMacNewItem {
            public int ID { get; set; }
            public string Mac { get; set; }
            public string DEC { get; set; }
            public string DateTimeCreated { get; set; }
        }

        RunAllModel Testing = myGlobal.myTesting.RAM;
        ObservableCollection<RunAllModel.ItemResult> results = myGlobal.myTesting.collectionResult;
        MSAccessDB db;

        public Database() {
            try {
                string db_file = AppDomain.CurrentDomain.BaseDirectory + "DB.accdb";
                db = new MSAccessDB(db_file);
                db.OpenConnection();
            }
            catch (Exception ex) {
                string data = "Function: constructor Database\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
            }
        }

        public bool saveLogTotal() {
            if (!db.IsConnected) return false;

            logTotalItem ldi = new logTotalItem() {
                UID = Testing.UID,
                Mac = Testing.macAddress,
                Login = results.Where(x => x.Name.Contains("Login telnet")).FirstOrDefault().Result,
                GetFirmware = results.Where(x => x.Name.Contains("Get firmware")).FirstOrDefault().Result,
                GetUID = results.Where(x => x.Name.Contains("Get uid")).FirstOrDefault().Result,
                GetMac = results.Where(x => x.Name.Contains("Get mac")).FirstOrDefault().Result,
                SetMac = results.Where(x => x.Name.Contains("Set mac")).FirstOrDefault().Result,
                VerifyMac = results.Where(x => x.Name.Contains("Verify mac")).FirstOrDefault().Result,
                TotalTime = Testing.totalTime,
                TotalResult = Testing.totalResult,
                DateTimeCreated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            };

            try {
                db.InsertDataToTable<logTotalItem>(ldi, "tbLogTotal", "ID");
                return true;
            }
            catch (Exception ex) {
                string data = "Function: saveLogTotal\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
        }

        public bool saveLogSystem() {
            if (!db.IsConnected) return false;

            logSystemItem lsi = new logSystemItem() {
                UID = Testing.UID,
                Mac = Testing.macAddress,
                Content = Testing.logSystem,
                TotalResult = Testing.totalResult,
                DateTimeCreated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            };

            try {
                db.InsertDataToTable<logSystemItem>(lsi, "tbLogSystem", "ID");
                return true;
            }
            catch (Exception ex) {
                string data = "Function: saveLogSystem\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
        }

        public bool saveLogTelnet() {
            if (!db.IsConnected) return false;

            logTelnetItem lti = new logTelnetItem() {
                UID = Testing.UID,
                Mac = Testing.macAddress,
                Content = Testing.logTelnet.Replace("\"", "").Replace("'", "").Trim(),
                TotalResult = Testing.totalResult,
                DateTimeCreated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            };

            try {
                db.InsertDataToTable<logTelnetItem>(lti, "tbLogTelnet", "ID");
                return true;
            }
            catch (Exception ex) {
                string data = "Function: saveLogTelnet\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
        }

        public bool saveMacWrited() {
            if (!db.IsConnected) return false;

            logMacWritedItem lwi = new logMacWritedItem() {
                UID = Testing.UID,
                Mac = Testing.macAddress,
                DateTimeWrited = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            };

            try {
                db.InsertDataToTable<logMacWritedItem>(lwi, "tbMacWrited", "ID");
                return true;
            }
            catch (Exception ex) {
                string data = "Function: saveMacWrited\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
        }

        public bool macIsWrited(string mac) {
            if (!db.IsConnected) return true;
            try {
                var item = db.QueryDataReturnObject<logMacWritedItem>("SELECT * FROM tbMacWrited WHERE Mac LIKE '%" + mac + "%';");
                return item != null;
            } catch (Exception ex) {
                string data = "Function: macIsWrited(string mac)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
            
        }

        public bool uidIsWrited(string uid) {
            if (!db.IsConnected) return true;
            try {
                var item = db.QueryDataReturnObject<logMacWritedItem>("SELECT * FROM tbMacWrited WHERE UID LIKE '%" + uid + "%';");
                return item != null;
            }
            catch (Exception ex) {
                string data = "Function: uidIsWrited(string uid)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
            
        }

        public bool writeMacNew(string mac, string dec) {
            if (!db.IsConnected) return false;
            logMacNewItem lmni = new logMacNewItem() {
                Mac = mac,
                DEC = dec,
                DateTimeCreated = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            };

            try {
                db.InsertDataToTable<logMacNewItem>(lmni, "tbMacNew", "ID");
                return true;
            }
            catch (Exception ex) {
                string data = "Function: writeMacNew(string mac)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
        }

        public bool deleteAllMacNew() {
            if (!db.IsConnected) return false;
            try {
                db.QueryDeleteOrUpdate("DELETE FROM tbMacNew");
                return true;
            }
            catch (Exception ex) {
                string data = "Function: deleteAllMacNew\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
        }

        public bool deleteMacNew(string mac) {
            if (!db.IsConnected) return false;
            try {
                db.QueryDeleteOrUpdate($"DELETE FROM tbMacNew WHERE Mac='{mac}'");
                return true;
            } catch (Exception ex) {
                string data = "Function: deleteMacNew(string mac)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return false;
            }
            
        }

        public List<logMacNewItem> getAllMacNew() {
            if (!db.IsConnected) return null;
            try {
                var data = db.QueryDataReturnListObject<logMacNewItem>("SELECT * FROM tbMacNew");
                if (data == null || data.Count == 0) return null;
                return data;
            } catch (Exception ex) {
                string data = "Function: getAllMacNew()\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return null;
            }
            
        }

        public string getLogSystemByUID(string uid) {
            if (!db.IsConnected) return null;
            try {
                var data = db.QueryDataReturnListObject<logSystemItem>("SELECT TOP 100 * FROM tbLogSystem WHERE UID LIKE '%" + uid + "%';");
                if (data == null || data.Count == 0) return null;
                return data[data.Count - 1].Content;
            } catch (Exception ex) {
                string data = "Function: getLogSystemByUID(string uid)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return null;
            }
           
        }

        public string getLogTelnetByUID(string uid) {
            if (!db.IsConnected) return null;
            try {
                var data = db.QueryDataReturnListObject<logSystemItem>("SELECT TOP 100 * FROM tbLogTelnet WHERE UID LIKE '%" + uid + "%';");
                if (data == null || data.Count == 0) return null;
                return data[data.Count - 1].Content;
            } catch (Exception ex) {
                string data = "Function: getLogTelnetByUID(string uid)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return null;
            }
            
        }

        public List<logTotalItem> getLogTotalByUID(string uid) {
            if (!db.IsConnected) return null;
            try {
                var data = db.QueryDataReturnListObject<logTotalItem>("SELECT TOP 100 * FROM tbLogTotal WHERE UID LIKE '%" + uid + "%';");
                if (data == null || data.Count == 0) return null;
                return data;
            } catch (Exception ex) {
                string data = "Function: getLogTotalByUID(string uid)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return null;
            }
            
        }

        public List<logMacWritedItem> getLogWritedByUID(string uid) {
            if (!db.IsConnected) return null;
            try {
                var data = db.QueryDataReturnListObject<logMacWritedItem>("SELECT TOP 100 * FROM tbMacWrited WHERE UID LIKE '%" + uid + "%';");
                if (data == null || data.Count == 0) return null;
                return data;
            } catch (Exception ex) {
                string data = "Function: getLogWritedByUID(string uid)\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
                return null;
            }
            
        }

        public void Close() {
            try {
                if (db != null && db.IsConnected == true) db.Close();
            } catch (Exception ex) {
                string data = "Function: Close\n";
                data += ex.ToString();
                Support.writeToDebugFile(data);
            }
            
        }

    }
}
