using IPCameraWriteMacWiFi.Models;
using IPCameraWriteMacWiFi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Base {

    public class IPCamera {
        Telnet<RunAllModel> camera;
        SettingModel Setting = myGlobal.mySetting.SM;
        RunAllModel Testing = myGlobal.myTesting.RAM;
        public bool isConnected = false;

        public IPCamera() {
            camera = new Telnet<RunAllModel>(Setting.ipAddress, 23, Testing);
            camera.Open();
            isConnected = camera.IsConnected;
        }

        public void Close() {
            if (isConnected) camera.Close();
        }

        public bool Login() {
            if (!isConnected) return false;
            try {
                string s = camera.Read();
                if (!s.TrimEnd().EndsWith("login:")) return false;
                camera.WriteLine(Setting.telnetUser);
                Thread.Sleep(300);

                s = camera.Read();
                if (!s.TrimEnd().EndsWith("Password:")) return false;
                camera.WriteLine(Setting.telnetPassword);
                Thread.Sleep(300);

                s = camera.Read();
                return s.Contains("#");
            } catch { 
                return false; 
            }
        }

        public string getFirmwareVersion() {
            if (!isConnected) return null;
            string s = camera.Query("cat /app/version", 3, 3, "_");
            if (!s.Contains("_")) return s;
            string[] buffer = s.Split('\n');
            string fw= buffer.Where(x => x.Contains("_")).FirstOrDefault();
            fw = fw.Split('_')[1].Replace("\"", "").Replace("\r", "").Trim();
            return fw;
        }

        public string getUID() {
            if (!isConnected) return null;
            string s = camera.Query("cat /mnt/mtd/database.db |grep uid", 3, 3, "\"uid\":");
            if (!s.Contains("\"uid\":")) return s;
            
            string[] buffer = s.Split('\n');
            string uid = buffer.Where(x => x.Contains("\"uid\":")).FirstOrDefault();
            uid = uid.Split(':')[1];
            uid = uid.Split(',')[0].Replace("\"", "").Replace("\r", "").Trim();
            return uid;
        }

        public string getMacWlan() {
            if (!isConnected) return null;
            string s = camera.Query("rtwpriv wlan0 efuse_get mac", 3, 3, "efuse_get:");
            if (!s.Contains("efuse_get:")) return s;

            string[] buffer = s.Split('\n');
            string mac = buffer.Where(x => x.Contains("efuse_get:")).FirstOrDefault();
            mac = mac.Split(new string[] { "efuse_get:" }, StringSplitOptions.None)[1].Replace("\"", "").Replace(":", "").Replace("\r", "").Trim();
            return mac;
        }

        public bool setMacWlan(string mac) {
            if (!isConnected) return false;
            string s = camera.Query($"rtwpriv wlan0 efuse_set mac,{mac}", 3, 3, "efuse_set:mac");
            return s.Contains("efuse_set:mac");
        }

        public bool setWlan0Up() {
            if (!isConnected) return false;
            string s = camera.Query($"ifconfig wlan0 up", 5, 3, "#");
            return s.Contains("#");
        }



    }
}
