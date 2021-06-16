using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.Base {
    public class OntEconet {

        Telnet<RunAllModel> ont;
        SettingModel Setting = myGlobal.mySetting.SM;
        RunAllModel Testing = myGlobal.myTesting.RAM;
        public bool isConnected = false;

        public OntEconet() {
            ont = new Telnet<RunAllModel>(Setting.ontIP, 23, Testing);
            ont.Open();
            isConnected = ont.IsConnected;
        }

        public void Close() {
            if (isConnected) ont.Close();
        }

        public bool Login() {
            if (!isConnected) return false;
            try {
                string s = ont.Read();
                if (!s.TrimEnd().EndsWith("login:")) return false;
                ont.WriteLine(Setting.ontUser);
                Thread.Sleep(300);

                s = ont.Read();
                if (!s.TrimEnd().EndsWith("Password:")) return false;
                ont.WriteLine(Setting.ontPassword);
                Thread.Sleep(300);

                s = ont.Read();
                return s.Contains("#");
            }
            catch {
                return false;
            }
        }

        public bool resetDhcp() {
            if (!isConnected) return false;
            string s = ont.Query("rm -rf /etc/udhcpd.leases", 3, 3, "#");
            if (!s.Contains("#")) return false;
            s = ont.Query("tcapi commit Dhcpd", 10, 3, "#");
            if (!s.Contains("#")) return false;
            return true;
        }
    }
}
