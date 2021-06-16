using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IPCameraWriteMacWiFi.Base {
    public class Support {

        public static bool pingToHost(string ip) {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            // Use the default Ttl value which is 128, 
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted. 
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 60;

            try {
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);
                if (reply.Status == IPStatus.Success) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch {
                return false;
            }
        }

        public static bool genMacAddress() {
            var setting = myGlobal.mySetting.SM;
            int start = int.Parse(setting.macStart);
            int end = int.Parse(setting.macEnd);
            int step = int.Parse(setting.macStep);

            App.Current.Dispatcher.Invoke(new Action(() => { myGlobal.myTesting.collectionMac.Clear(); }));
            
            Database db = new Database();
            db.deleteAllMacNew();
            myGlobal.myGenerate.GMAM.pgMax = ((end - start) / step) + 1;
            myGlobal.myGenerate.GMAM.pgValue = 0;
            for (int i = start; i <= end; i += step) {
                string data = string.Format("{0:x}", i).ToUpper().PadLeft(6, '0');
                string mac = $"{setting.macHeader}{data}";
                db.writeMacNew(mac, i.ToString());
                myGlobal.myGenerate.GMAM.pgValue++;
            }
            db.Close();
            loadMacNewFromDBToCollection();

            return true;
        }
    
        public static bool loadMacNewFromDBToCollection() {
            Database db = new Database();
            var ds = db.getAllMacNew();
            if (ds == null || ds.Count == 0) return true;
            
            foreach (var d in ds) {
                RunAllModel.FreeMacAddress free = new RunAllModel.FreeMacAddress() { macAddress = d.Mac, macDEC = d.DEC };
                App.Current.Dispatcher.Invoke(new Action(() => { myGlobal.myTesting.collectionMac.Add(free); }));
            }
            myGlobal.myTesting.RAM.macRemain = ds.Count.ToString();
            myGlobal.myTesting.RAM.macCurrent = ds[0].DEC;
            return true;
        }
        
        public static bool writeToDebugFile(string data) {
            try {
                string f = AppDomain.CurrentDomain.BaseDirectory + "Debug.txt";
                using (StreamWriter sw = new StreamWriter(f, true, Encoding.Unicode)) {
                    sw.WriteLine(data);
                }
                return true;
            } catch {
                return false;
            }   
        }

        public static bool deleteDebugFile() {
            try {
                string f = AppDomain.CurrentDomain.BaseDirectory + "Debug.txt";
                if (File.Exists(f) == true)
                    File.Delete(f);
                return true;
            } catch { return false; }
        }

    
    }
}
