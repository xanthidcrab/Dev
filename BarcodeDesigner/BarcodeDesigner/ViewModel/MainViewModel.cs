using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using MVVM_Base;
using MVVM_Base.Interfaces;
namespace BarcodeDesigner.ViewModel
{
    public class MainViewModel : ObserrvableObject
    {
		private ObserrvableObject _CurrentView;
        private readonly INavigationService navigationService;

        public ObserrvableObject CurrentView
		{
			get => _CurrentView;
			set => SetProperty(ref _CurrentView, value);
        }


        public ICommand NavigateHomePageCommand { get;  }
        public ICommand NavigateSettingsPageCommand { get; }


        public MainViewModel(INavigationService navigationService)
        {
           
            this.navigationService = navigationService;
            navigationService.SetMainViewModel<MainViewModel>();
            NavigateHomePageCommand = new RelayCommand(() =>
           navigationService.NavigateTo<HomePageViewModel>());

            NavigateSettingsPageCommand = new RelayCommand(() =>
                navigationService.NavigateTo<SettingsPageViewModel>());

            // İlk açılış sayfası
            navigationService.NavigateTo<HomePageViewModel>();
        }

       
    }
}
