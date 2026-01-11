using DxfService;
using DxfService.Contracts;
using DxfViewer.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DxfViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IHost host { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                     services.AddSingleton<MainWindow>();
                    services.AddTransient<IDxfSerrvice, DxfService.DxfService>();
                    services.AddSingleton<MainViewModel>();
                })
                .Build();
            var mw = host.Services.GetRequiredService<MainWindow>();
            mw.DataContext = host.Services.GetRequiredService<MainViewModel>();
            mw.Show();
            base.OnStartup(e);
        }


    }

}
