using IPCameraWriteMacWiFi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IPCameraWriteMacWiFi.Commands;
using IPCameraWriteMacWiFi.Base;

namespace IPCameraWriteMacWiFi.ViewModels {
    public class RunAllViewModel {

        public RunAllViewModel() {
            _ram = new RunAllModel();

            //init collection
            _collection_result = new ObservableCollection<RunAllModel.ItemResult>() { 
            new RunAllModel.ItemResult() { Name = "Ping to camera" },
            new RunAllModel.ItemResult() { Name = "Login telnet to camera" },
            new RunAllModel.ItemResult() { Name = "Get firmware version" },
            new RunAllModel.ItemResult() { Name = "Get uid from camera" },
            new RunAllModel.ItemResult() { Name = "Get mac from list" },
            new RunAllModel.ItemResult() { Name = "Set mac to camera" },
            new RunAllModel.ItemResult() { Name = "Verify mac from camera" },
            };
            _collection_mac = new ObservableCollection<RunAllModel.FreeMacAddress>();
            _collection_total = new ObservableCollection<Database.logTotalItem>();
            _collection_writed = new ObservableCollection<Database.logMacWritedItem>();

            //set command
            StartCommand = new RunAllStartCommand(this);
            SearchLogSystemCommand = new RunAllSearchLogSystemCommand(this);
            SearchLogTelnetCommand = new RunAllSearchLogTelnetCommand(this);
            SearchLogTotalCommand = new RunAllSearchLogTotalCommand(this);
            SearchLogMacCommand = new RunAllSearchLogMacCommand(this);
        }


        RunAllModel _ram;
        public RunAllModel RAM {
            get => _ram;
        }

        ObservableCollection<RunAllModel.ItemResult> _collection_result;
        public ObservableCollection<RunAllModel.ItemResult> collectionResult {
            get { return _collection_result; }
            set { _collection_result = value; }
        }

        ObservableCollection<RunAllModel.FreeMacAddress> _collection_mac;
        public ObservableCollection<RunAllModel.FreeMacAddress> collectionMac {
            get { return _collection_mac; }
            set { _collection_mac = value; }
        }

        ObservableCollection<Database.logTotalItem> _collection_total;
        public ObservableCollection<Database.logTotalItem> collectionTotal {
            get { return _collection_total; }
            set { _collection_total = value; }
        }

        ObservableCollection<Database.logMacWritedItem> _collection_writed;
        public ObservableCollection<Database.logMacWritedItem> collectionWrited {
            get { return _collection_writed; }
            set { _collection_writed = value; }
        }

        public void ClearCollectionResult() {
            foreach (var item in _collection_result) {
                item.Result = item.totalTime = item.Value = "";
            }
        }

        //command
        public ICommand StartCommand {
            get;
            private set;
        }
        public ICommand SearchLogSystemCommand {
            get;
            private set;
        }
        public ICommand SearchLogTelnetCommand {
            get;
            private set;
        }
        public ICommand SearchLogTotalCommand {
            get;
            private set;
        }
        public ICommand SearchLogMacCommand {
            get;
            private set;
        }

    }
}
