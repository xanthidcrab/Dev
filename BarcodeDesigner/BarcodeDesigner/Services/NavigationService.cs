using Microsoft.Extensions.DependencyInjection;
using MVVM_Base.Interfaces;
using MVVM_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeDesigner.ViewModel;

namespace BarcodeDesigner.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private MainViewModel _mainViewModel;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SetMainViewModel<TViewModel>() where TViewModel : ObserrvableObject
        {
            _mainViewModel = _serviceProvider.GetRequiredService<TViewModel>() as MainViewModel;
        }
      

        public void NavigateTo<TViewModel>() where TViewModel : ObserrvableObject
        {
            var vm = _serviceProvider.GetRequiredService<TViewModel>();
            _mainViewModel.CurrentView = vm;
        }
    }
}
