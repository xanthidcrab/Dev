using Autofac;
using LangExamples.MVVM.ViewModel;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace LangExamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Autofac.IContainer Container { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LanguageService>().As<ILangService>().SingleInstance();
            builder.RegisterType<MVVM.ViewModel.UILanguageViewModel>().AsSelf().SingleInstance();


            Container = builder.Build();
            var mainWindow = new MainWindow
            {
                DataContext = Container.Resolve<UILanguageViewModel>()
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
