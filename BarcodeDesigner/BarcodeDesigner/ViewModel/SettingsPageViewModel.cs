using MVVM_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeDesigner.ViewModel
{
    public class SettingsPageViewModel : ObserrvableObject
    {
        public string Test { get; set; }


        public SettingsPageViewModel()
        {
            Test = "Settings Page View Model Initialized";
        }


    }
}
