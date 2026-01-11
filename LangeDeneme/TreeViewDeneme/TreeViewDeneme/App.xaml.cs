using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using TreeViewDeneme.ViewModel;
using MVVM_Base;
using TreeViewDeneme.View;
namespace TreeViewDeneme
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Set the main window to be the MainWindow.xaml
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainPage>().AsSelf();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<MainPageViewModel>();

            //register services 
            builder.RegisterType<Services.XmlService>().As<Services.Interfaces.IXmlService>();
            Container = builder.Build();
            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
