using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Autofac;
using MVVM_Base;
using TreeViewDeneme.Model;
using TreeViewDeneme.Services.Interfaces;
namespace TreeViewDeneme.ViewModel
{
    public class MainViewModel:ObserrvableObject
    {

        private ObserrvableObject _CurrentViewModel;

        public ObserrvableObject CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        private ContentModel _ContentModel;
        private readonly IXmlService xmlService;

        public ContentModel ContentModel
        {
            get { return _ContentModel; }
            set { SetProperty(ref _ContentModel, value); }
        }
        public ICommand ExitCommand { get; set; }
        public MainViewModel(IXmlService xmlService)
        {
            ExitCommand = new RelayCommand(ExitApplication);
            this.xmlService = xmlService;
            xmlService.LoadXml<XMLMODEL>("G:\\Dev\\LangeDeneme\\TreeViewDeneme\\TreeViewDeneme\\381960.xml");
            CurrentViewModel = App.Container.Resolve<MainPageViewModel>();
            ContentModel = new ContentModel();
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown(); 
        }
    }
}
