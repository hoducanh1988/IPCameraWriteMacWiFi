using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class TabHeaderViewModel {

        public TabHeaderViewModel() {
            _thm = new TabHeaderModel();
        }

        TabHeaderModel _thm;
        public TabHeaderModel THM {
            get => _thm;
        }


    }
}
