using IPCameraWriteMacWiFi.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IPCameraWriteMacWiFi.Views {
    /// <summary>
    /// Interaction logic for RunAllView.xaml
    /// </summary>
    public partial class RunAllView : UserControl {
        public RunAllView() {
            InitializeComponent();
            this.DataContext = myGlobal.myTesting;
            Support.loadMacNewFromDBToCollection();
        }
    }

    public class BrushColorConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            bool r = myGlobal.myTesting.RAM.instructionText.ToLower().Contains("error");
            return r ? Brushes.Red : Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
