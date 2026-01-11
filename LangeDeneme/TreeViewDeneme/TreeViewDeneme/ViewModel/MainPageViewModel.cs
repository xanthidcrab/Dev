using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Base;
using TreeViewDeneme.Model;
using TreeViewDeneme.Services.Interfaces;
namespace TreeViewDeneme.ViewModel
{
    public class MainPageViewModel: ObserrvableObject
    {
       
        private ObservableCollection<XMLMODEL> _XmlList;
        private readonly IXmlService xmlService;

        public ObservableCollection<XMLMODEL> XmlList
        {
            get { return _XmlList; }
            set { SetProperty(ref _XmlList, value); }
        }
        public MainPageViewModel(IXmlService _xmlService)
        {
            xmlService = _xmlService;
            XmlList = new ObservableCollection<XMLMODEL>();
            LoadFiles();
        }

        private void LoadFiles()
        {
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "PROFILES\\", "*.xml");
            foreach (var file in files)
            {
                XmlList.Add(xmlService.LoadXml<XMLMODEL>(file));
            }
        }
    }

}
