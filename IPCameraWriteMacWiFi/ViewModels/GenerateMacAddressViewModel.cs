using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class GenerateMacAddressViewModel {

        public GenerateMacAddressViewModel() {
            _gmam = new GenerateMacAddressModel();
        }

        GenerateMacAddressModel _gmam;
        public GenerateMacAddressModel GMAM {
            get => _gmam;
        }

    }
}
