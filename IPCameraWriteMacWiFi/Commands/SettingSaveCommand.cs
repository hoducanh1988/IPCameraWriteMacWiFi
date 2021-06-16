using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;

using UtilityPack.IO;
using UtilityPack.Validation;
using UtilityPack.Converter;
using IPCameraWriteMacWiFi.Base;
using IPCameraWriteMacWiFi.Views;
using IPCameraWriteMacWiFi.Models;
using IPCameraWriteMacWiFi.ViewModels;

namespace IPCameraWriteMacWiFi.Commands {
    public class SettingSaveCommand : ICommand {

        private SettingViewModel _svm;
        public SettingSaveCommand(SettingViewModel svm) {
            _svm = svm;
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
            string msg;
            bool r = checkSetting(out msg);
            if (!r) {
                System.Windows.MessageBox.Show(msg, "Setting Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }

            GenMac();
            XmlHelper<SettingModel>.ToXmlFile(_svm.SM, AppDomain.CurrentDomain.BaseDirectory + "setting.xml");
            System.Windows.MessageBox.Show("Sucess!", "Save Setting", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        #endregion

        #region sub-function

        void GenMac() {
            string[] data = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "setting.xml");
            string mac_header = data.Where(x => x.Contains("<macHeader>")).FirstOrDefault().Replace("<macHeader>", "").Replace("</macHeader>", "").Replace("\r", "").Trim();
            string mac_start = data.Where(x => x.Contains("<macStart>")).FirstOrDefault().Replace("<macStart>", "").Replace("</macStart>", "").Replace("\r", "").Trim();
            string mac_end = data.Where(x => x.Contains("<macEnd>")).FirstOrDefault().Replace("<macEnd>", "").Replace("</macEnd>", "").Replace("\r", "").Trim();
            string mac_step = data.Where(x => x.Contains("<macStep>")).FirstOrDefault().Replace("<macStep>", "").Replace("</macStep>", "").Replace("\r", "").Trim();

            bool r = mac_header.Equals(_svm.SM.macHeader) == false ||
                     mac_start.Equals(_svm.SM.macStart) == false ||
                     mac_end.Equals(_svm.SM.macEnd) == false ||
                     mac_step.Equals(_svm.SM.macStep) == false;
            if (r) {
                GenerateMacAddress gma = new GenerateMacAddress();
                gma.ShowDialog();
            }
        }

        bool checkSetting(out string msg) {
            bool r = false;
            msg = "";
            var setting = _svm.SM;
            
            //check ip address
            r = Parse.IsIPAddress(setting.ipAddress);
            if (!r) {
                msg = $"IP address {setting.ipAddress} sai định dạng.";
                return false;
            }

            //check telnet user
            r = string.IsNullOrEmpty(setting.telnetUser) || string.IsNullOrWhiteSpace(setting.telnetUser);
            if (r) {
                msg = $"Telnet user {setting.telnetUser} sai định dạng.";
                return false;
            }

            //check telnet password
            r = string.IsNullOrEmpty(setting.telnetPassword) || string.IsNullOrWhiteSpace(setting.telnetPassword);
            if (r) {
                msg = $"Telnet password {setting.telnetPassword} sai định dạng.";
                return false;
            }

            //check firmware version
            r = string.IsNullOrEmpty(setting.firmwareVersion) || string.IsNullOrWhiteSpace(setting.firmwareVersion);
            if (r) {
                msg = $"Firmware version {setting.firmwareVersion} sai định dạng.";
                return false;
            }

            //check mac header
            r = setting.macHeader.Equals("A06518") || setting.macHeader.Equals("A4F4C2") || setting.macHeader.Equals("D49AA0");
            if (!r) {
                msg = $"Mac header {setting.macHeader} không đúng dải VNPTT A06518:A4F4C2:D49AA0.";
                return false;
            }

            //check mac start
            int start;
            r = int.TryParse(setting.macStart, out start);
            if (!r) {
                msg = $"Mac bắt đầu {setting.macStart} không đúng.";
                return false;
            }
            r = start < 0 || start >= 16777215;
            if (r) {
                msg = $"Mac bắt đầu {setting.macStart} không đúng.";
                return false;
            }

            //check mac end
            int end;
            r = int.TryParse(setting.macEnd, out end);
            if (!r) {
                msg = $"Mac kết thúc {setting.macEnd} không đúng.";
                return false;
            }
            r = end <= 0 || end >= 16777215;
            if (r) {
                msg = $"Mac kết thúc {setting.macEnd} không đúng.";
                return false;
            }
            r = end < start;
            if (r) {
                msg = $"Mac kết thúc {setting.macEnd} nhỏ hơn bắt đầu.";
                return false;
            }

            //check mac step
            int step;
            r = int.TryParse(setting.macStep, out step);
            if (!r) {
                msg = $"Bước nhảy {setting.macStep} không đúng.";
                return false;
            }
            r = step <= 0;
            if (r) {
                msg = $"Bước nhảy {setting.macStep} không được <=0.";
                return false;
            }
            r = step > 8;
            if (r) {
                msg = $"Bước nhảy {setting.macStep} không được >8.";
                return false;
            }

            return true;
        }

        #endregion

    }
}
