using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class AboutViewModel {

        public AboutViewModel() {
            _abouts = new ObservableCollection<AboutModel>();
            _abouts.Add(new AboutModel() { ID = "1", Version = "OEMCAMVN0U0001", Content = "- Phát hành lần đầu (27/05/2021).\n- Update lệnh wlan up trước khi set mac(10/06/2021).", Date = "10/06/2021", ChangeType = "Tạo mới", Person = "Hồ Đức Anh" });
        }

        ObservableCollection<AboutModel> _abouts;
        public ObservableCollection<AboutModel> Abouts {
            get { return _abouts; }
            set { _abouts = value; }
        }

    }
}
