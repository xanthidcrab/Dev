using Autofac;
using MVVM_Base;
using MVVM_Base.Interfaces;
using MVVM_Navigation_Example.Factories;
using MVVM_Navigation_Example.View;
using MVVM_Navigation_Example.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Navigation_Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            // Register ViewModels
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<ManualViewModel>().AsSelf();
            builder.RegisterType<SettingsViewModel>().AsSelf();
            builder.RegisterType<AutoViewModel>().AsSelf();


            builder.RegisterType<RelayCommand>().AsSelf();

            // Register Views
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<AutoControl>().AsSelf();
            builder.RegisterType<ManaulControl>().AsSelf();
            builder.RegisterType<SettingsControl>().AsSelf();

            // Register services (example)
            //builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            //Register Factories
            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>().SingleInstance();
            builder.RegisterType<RelayCommandFactory>().As<IRelayCommandFactory>().SingleInstance();


            Container = builder.Build();

            // Resolve and show MainWindow
            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.DataContext = Container.Resolve<MainViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
