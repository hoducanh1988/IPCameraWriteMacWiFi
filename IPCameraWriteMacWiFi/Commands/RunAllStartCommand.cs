using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using System.Diagnostics;

using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.Models;
using System.Collections.ObjectModel;
using IPCameraWriteMacWiFi.ViewModels;
using UtilityPack.Converter;

namespace IPCameraWriteMacWiFi.Commands {
    public class RunAllStartCommand : ICommand {
        private RunAllViewModel ravm;
        RunAllModel testing;
        SettingModel setting;
        ObservableCollection<RunAllModel.ItemResult> results;
        Database db;

        public RunAllStartCommand(RunAllViewModel _ravm) {
            ravm = _ravm;
            testing = ravm.RAM;
            setting = myGlobal.mySetting.SM;
            results = ravm.collectionResult;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //enable button save setting
        public bool CanExecute(object parameter) {
            return true;
        }

        //save setting
        public void Execute(object parameter) {

            Task t = new Task(() => {
                testing.buttonContent = "Stop";
                int idx = 0;

            RE_AUTO_START:
                idx++;
                bool r = false;
                testing.Init();
                ravm.ClearCollectionResult();
                db = new Database();
                testing.instructionText = idx == 1 ? $"Kết nối LAN giữa sản phẩm với ONT và chờ trong giây lát." : "Cắm dây LAN vào sản phẩm tiếp theo và chờ trong giây lát.";

                //ping on
                pingCameraON();

                //Login
                testing.instructionText = $"Đang thực hiện các bước để ghi mac wifi cho sản phẩm...";
                IPCamera camera;
                r = loginToCamera(out camera);
                if (!r) {
                    var item = results.Where(x => x.Name.Contains("Login telnet")).FirstOrDefault();
                    testing.instructionText = $"Error: không thể telnet vào camera {item.Value}.";
                    goto END;
                }
                //get firmwre version
                r = getFirmwareVersion(camera);
                if (!r) {
                    var item = results.Where(x => x.Name.Contains("Get firmware")).FirstOrDefault();
                    testing.instructionText = $"Error: firmware version camera {item.Value} không đúng với setting {setting.firmwareVersion}.";
                    goto END;
                }

                //get uid
                r = getUID(camera); if (!r) goto END;
                if (db.uidIsWrited(testing.UID) == true) {
                    testing.instructionText = $"Error: UID {testing.UID} đã được ghi mac.";
                    r = false;
                    goto END;
                }

                //get mac from list
                string mac;
                r = getMac(db, out mac);
                if (!r) {
                    testing.instructionText = $"Error: không lấy được địa chỉ mac mới.";
                    goto END;
                }

                //set mac wifi
                r = setMAC(camera, mac);
                if (!r) {
                    testing.instructionText = $"Error: không ghi được địa chỉ mac wifi cho camera.";
                    goto END;
                }

                //check mac wifi
                r = checkMAC(camera, mac);
                if (!r) {
                    testing.instructionText = $"Error: không ghi được địa chỉ mac wifi cho camera.";
                    goto END;
                }

            END:
                Judge(camera, r);

                //ping off
                pingCameraOFF();

                //reset ont dhcp server
                testing.instructionText = $"Đang reset dhcp server. Vui lòng đợi trong giây lát...";
                resetDhcpInfo();

                goto RE_AUTO_START;
            });
            t.Start();

            Task v = new Task(() => {
                Stopwatch st = new Stopwatch();
            RE:
                if (testing.isTesting == true) {
                    if (st.IsRunning == false) { st.Restart(); }
                    else {
                        testing.totalTime = myConverter.intToTimeSpan((int)st.ElapsedMilliseconds);
                    }
                }
                else { st.Stop(); st.Reset(); }
                Thread.Sleep(500);
                goto RE;
            });
            v.Start();
        }

        #endregion

        #region sub - function

        void pingCameraON() {
            //ping to camera
            bool r = false;
            int c = 0;

            //ping on
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Pinging {setting.ipAddress} with 32 bytes of data:\n";
            var item = results.Where(x => x.Name.Contains("Ping")).FirstOrDefault();
            item.Value = setting.ipAddress;
            item.Result = "Waiting...";
        RE_PING:
            Thread.Sleep(1000);
            r = Support.pingToHost(setting.ipAddress);
            testing.logSystem += r ? $"... Reply from {setting.ipAddress}: bytes=32 time<1ms TTL=64\n" : "Request timed out.\n";
            if (!r) { c = 0; goto RE_PING; }
            c++;
            if (c < 3) goto RE_PING;
            item.Result = "Passed";
            testing.logSystem += $"... Result = {item.Result}\n";

        }

        bool loginToCamera(out IPCamera camera) {
            Stopwatch st = new Stopwatch();
            st.Start();
            bool r = false;
            int c = 0;
            testing.isTesting = true;
            testing.totalResult = "Waiting...";
            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Login to camera ({setting.telnetUser}, {setting.telnetPassword}):\n";
            var item = results.Where(x => x.Name.Contains("Login")).FirstOrDefault();
            item.Value = $"{setting.telnetUser},{setting.telnetPassword}";
            item.Result = "Waiting...";
        RE_LOGIN:
            c++;
            camera = new IPCamera();
            r = camera.Login();
            testing.logSystem += $"... Result[{c}] = {r}\n";
            if (!r) {
                if (c < 3) { Thread.Sleep(1000); goto RE_LOGIN; }
                r = false;
                goto END;
            }
            r = true;

        END:
            st.Stop();
            item.Result = r ? "Passed" : "Failed";
            item.totalTime = st.ElapsedMilliseconds.ToString();
            return r;

        }

        bool getFirmwareVersion(IPCamera camera) {
            Stopwatch st = new Stopwatch();
            st.Start();
            bool r = false;
            int c = 0;
            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Get firmware version from camera:\n";
            testing.logSystem += $"... Firmware version setting = {setting.firmwareVersion}\n";
            var item = results.Where(x => x.Name.Contains("Get firmware")).FirstOrDefault();
            item.Result = "Waiting...";
        RE_GET_FW:
            c++;
            string fw = camera.getFirmwareVersion();
            testing.logSystem += $"... Firmware version camera [{c}] = {fw}\n";
            item.Value = fw;
            if (fw == null) {
                if (c < 3) { Thread.Sleep(1000); goto RE_GET_FW; }
                r = false;
                goto END;
            }

            r = item.Value.Equals(setting.firmwareVersion);
            goto END;

        END:
            item.Result = r ? "Passed" : "Failed";
            testing.logSystem += $"... Result = {item.Result}\n";
            st.Stop();
            item.totalTime = st.ElapsedMilliseconds.ToString();
            return r;
        }

        bool getUID(IPCamera camera) {
            Stopwatch st = new Stopwatch();
            st.Start();
            bool r = false;
            int c = 0;
            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Get UID from camera:\n";
            var item = results.Where(x => x.Name.Contains("Get uid")).FirstOrDefault();
            item.Result = "Waiting...";
        RE_GET_UID:
            c++;
            string uid = camera.getUID();
            testing.logSystem += $"... UID from camera [{c}] = {uid}\n";
            item.Value = uid;
            testing.UID = item.Value;
            if (uid == null) {
                if (c < 3) { Thread.Sleep(1000); goto RE_GET_UID; }
                r = false;
                goto END;
            }
            r = true;

        END:
            st.Stop();
            item.Result = r ? "Passed" : "Failed";
            item.totalTime = st.ElapsedMilliseconds.ToString();
            return r;
        }

        bool getMac(Database db, out string mac) {
            Stopwatch st = new Stopwatch();
            st.Start();
            bool r = false;
            mac = null;
            RunAllModel.ItemResult item = null;
            int mac_count = 0;
            App.Current.Dispatcher.Invoke(new Action(() => {
                item = results.Where(x => x.Name.Contains("Get mac")).FirstOrDefault();
                item.Result = "Waiting...";
                mac_count = myGlobal.myTesting.collectionMac.Count;
            }));
            if (mac_count == 0) goto END;
            int c = 0;
            int max_count = 100;
        RE:
            c++;
            string data = "";
            App.Current.Dispatcher.Invoke(new Action(() => {
                data = myGlobal.myTesting.collectionMac.Count > 0 ? myGlobal.myTesting.collectionMac[0].macAddress : null;
            }));
            if (data == null) { r = false; goto END; }
            mac = data;

            if (db.macIsWrited(mac) == true) {
                //remove collection
                App.Current.Dispatcher.Invoke(new Action(() => { myGlobal.myTesting.collectionMac.RemoveAt(0); }));

                //remove database
                db.deleteMacNew(mac);

                if (c < max_count) goto RE;
                r = false;
                goto END;
            }
            item.Value = mac;
            r = true;

        END:
            st.Stop();
            item.Result = r ? "Passed" : "Failed";
            item.totalTime = st.ElapsedMilliseconds.ToString();
            return r;
        }

        bool setMAC(IPCamera camera, string mac) {
            Stopwatch st = new Stopwatch();
            st.Start();
            bool r = false;
            int c = 0;

            var item = results.Where(x => x.Name.Contains("Set mac")).FirstOrDefault();
            item.Result = "Waiting...";
            item.Value = $"{mac}";

            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Set wlan0 up:\n";
        RE_SET_WLAN:
            c++;
            r = camera.setWlan0Up();
            testing.logSystem += $"... Result[{c}] = {r}\n";
            if (!r) {
                if (c < 3) { Thread.Sleep(1000); goto RE_SET_WLAN; }
                r = false;
                goto END;
            }

            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Set mac wifi to camera ({mac}):\n";
            testing.macAddress = item.Value;
            c = 0;
            r = false;
        RE_SET_MAC:
            c++;
            r = camera.setMacWlan(mac);
            testing.logSystem += $"... Result[{c}] = {r}\n";
            if (!r) {
                if (c < 3) { Thread.Sleep(1000); goto RE_SET_MAC; }
                r = false;
                goto END;
            }
            r = true;

        END:
            item.Result = r ? "Passed" : "Failed";
            st.Stop();
            item.totalTime = st.ElapsedMilliseconds.ToString();
            return r;
        }

        bool checkMAC(IPCamera camera, string mac) {
            Stopwatch st = new Stopwatch();
            st.Start();
            bool r = false;
            int c = 0;
            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Check mac wifi from camera :\n";
            testing.logSystem += $"... Standard = {mac}\n";
            var item = results.Where(x => x.Name.Contains("Verify mac")).FirstOrDefault();
            item.Result = "Waiting...";
        RE_GET_MAC:
            c++;
            string m = camera.getMacWlan();
            testing.logSystem += $"... Mac from camera[{c}] = {m}\n";
            item.Value = m;
            r = m.ToLower().Equals(mac.ToLower());
            if (!r) {
                if (c < 3) { Thread.Sleep(1000); goto RE_GET_MAC; }
                r = false;
                goto END;
            }
            r = true;

        END:
            item.Result = r ? "Passed" : "Failed";
            st.Stop();
            item.totalTime = st.ElapsedMilliseconds.ToString();
            testing.logSystem += $"... Result = {item.Result}\n";
            return r;
        }

        void pingCameraOFF() {
            bool r = false;
            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Vui lòng rút dây LAN ra khỏi camera.\n";
        RE_OFF:
            Thread.Sleep(1000);
            r = Support.pingToHost(setting.ipAddress);
            if (r) { goto RE_OFF; }
        }

        bool resetDhcpInfo() {
            bool r = false;
            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Reset dhcp server info:\n";
            OntEconet ont = new OntEconet();
            r = ont.Login(); if (!r) goto END;
            r = ont.resetDhcp();
            
            END:
            ont.Close();
            testing.logSystem += $"... Result = {r}\n";
            return r;
        }

        void Judge(IPCamera camera, bool ret) {
            camera.Close();
            testing.totalResult = ret ? "Passed" : "Failed";
            testing.isTesting = false;

            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"UID: { testing.UID }\n";
            testing.logSystem += $"Mac address: { testing.macAddress }\n";
            testing.logSystem += $"Total result: { testing.totalResult }\n";
            testing.logSystem += $"Total time: { testing.totalTime }\n";
            testing.logSystem += $"{ testing.instructionText }\n";

            testing.logSystem += "\n";
            testing.logSystem += DateTime.Now.ToString() + "\n";
            testing.logSystem += $"Save log to DB.accdb :\n";
            bool r = saveLog(ret);
            testing.logSystem += $"... Result = {(r ? "Passed" : "Failed")}\n";
        }

        bool saveLog(bool ret) {
            try {
                db.saveLogTotal();
                db.saveLogSystem();
                db.saveLogTelnet();
                if (ret == true) {
                    db.saveMacWrited();
                    App.Current.Dispatcher.Invoke(new Action(() => {
                        var item = myGlobal.myTesting.collectionMac.Where(x => x.macAddress.Equals(testing.macAddress)).FirstOrDefault();
                        myGlobal.myTesting.collectionMac.Remove(item); ////remove collection
                        string mac = myGlobal.myTesting.collectionMac[0].macAddress;
                        myGlobal.myTesting.RAM.macCurrent = Convert.ToInt64(mac.Substring(6,6), 16).ToString();
                        myGlobal.myTesting.RAM.macRemain = myGlobal.myTesting.collectionMac.Count.ToString();
                    }));
                    db.deleteMacNew(testing.macAddress); ////remove database
                }
                db.Close();
                return true;
            }
            catch { return false; }
        }

        #endregion

    }
}
