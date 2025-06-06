using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Base;
using MVVM_Base.Interfaces;
namespace MVVM_Navigation_Example.ViewModel
{
    public class MainViewModel : ObserrvableObject
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IRelayCommandFactory relayCommandFactory;

        public ICommand NavigateAutoCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateManualCommand { get; }

        private ObserrvableObject _currentViewModel;
        public ObserrvableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public MainViewModel(IViewModelFactory viewModelFactory, IRelayCommandFactory relayCommandFactory)
        {
            _viewModelFactory = viewModelFactory;
            this.relayCommandFactory = relayCommandFactory;
         

            NavigateAutoCommand = relayCommandFactory.Create(NavigateToAuto);
            NavigateManualCommand = relayCommandFactory.Create(NavigateToSettings);
            NavigateSettingsCommand = relayCommandFactory.Create(NavigateToManual);



            CurrentViewModel = _viewModelFactory.CreateViewModel<AutoViewModel>();
        }

        private void NavigateToAuto()
        {
            CurrentViewModel = _viewModelFactory.CreateViewModel<AutoViewModel>();
        }

        private void NavigateToSettings()
        {
            CurrentViewModel = _viewModelFactory.CreateViewModel<SettingsViewModel>();
        }

        private void NavigateToManual()
        {
            CurrentViewModel = _viewModelFactory.CreateViewModel<ManualViewModel>();
        }
    }

}
