using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using TaskDeneme.Services;
using TaskDeneme.Services.Contracts;
using TaskDeneme.ViewModel;

namespace TaskDeneme
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost Host { get; private set; }




        protected override void OnStartup(StartupEventArgs e)
        {
            Host = new HostBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IPollingService, PollingService>();
                services.AddSingleton<IUiUpdateService, UiUpdateService>();
                services.AddSingleton<ControlViewModel>();
                services.AddHostedService<PlcPollingBackgroundService>();

            })
            .Build();
 

            var mainWindow = new MainWindow
            {
                DataContext = Host.Services.GetRequiredService<ControlViewModel>()
            };

            mainWindow.Show();

            Host.Start();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Host.Dispose();
            base.OnExit(e);
        }
    }

}
