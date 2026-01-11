using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Base;
namespace TreeViewDeneme.Model
{
    public class ContentModel: ObserrvableObject
    {

        private string _ExitButton;

        public string ExitButton
        {
            get { return _ExitButton; }
            set { SetProperty(ref _ExitButton, value); }
        }
        public ContentModel()
        {
            ExitButton = "Exit";
        }
    }
}
