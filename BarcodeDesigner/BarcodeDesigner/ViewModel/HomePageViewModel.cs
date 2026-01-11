using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Base;
namespace BarcodeDesigner.ViewModel
{
    public class HomePageViewModel : ObserrvableObject
    {
        public string Test { get; set; }
        public HomePageViewModel()
        {
            Test = "Home Page View Model Initialized";
        }
    }
}
