using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2
{
    [ObservableObject]
    public partial class ViewModel :ObservableObject
    {

        [ObservableProperty]
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        [ObservableProperty]
        public string Text2 { get; set; }
        [ObservableProperty]
        public ICommand ClickMeCommand { get; set; }
        public ViewModel()
        {
            Text = "Hello, World!";
            Text2 = "Hello, World 2!";
            ClickMeCommand = new AsyncRelayCommand(OnClickMe);
        }

        private async Task OnClickMe()
        {
            if (true)
            {
                while (true)
                {
                    await Task.Delay(1000);
                    Text = DateTime.Now.ToString("T");
                    Text2 = DateTime.Now.ToString("T");
                }
            }
            
        }
    }
}
