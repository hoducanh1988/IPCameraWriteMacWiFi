using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPCameraWriteMacWiFi.Models;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class HelpViewModel {

        public HelpViewModel() {
            _hm = new HelpModel();
        }

        HelpModel _hm;
        public HelpModel HM {
            get => _hm;
        }

    }
}
