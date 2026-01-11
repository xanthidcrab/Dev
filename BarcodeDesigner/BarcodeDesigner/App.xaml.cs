using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BarcodeDesigner.Services;
using BarcodeDesigner.View.Pages;
using BarcodeDesigner.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using MVVM_Base;
using MVVM_Base.Interfaces;
namespace BarcodeDesigner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            // Set the DataContext of the MainWindow to the MainViewModel
            mainWindow.DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
         
            mainWindow.Show();
            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register your services here, e.g.:
            services.AddSingleton<MainWindow>();
            services.AddSingleton<HomePage>();
            services.AddSingleton<SettingsPage>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<SettingsPageViewModel>();
            services.AddTransient<INavigationService, NavigationService>();


        }
    }
}
