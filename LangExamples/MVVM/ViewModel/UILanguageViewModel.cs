using LangExamples.Core;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LangExamples.MVVM.ViewModel
{
    public class UILanguageViewModel : ObserrvableObject
    {
        public string HelloWorld => langService.Get("HelloWorld", Properties.Resources.ResourceManager);
        public string HelloWorld1 => langService.Get("HelloWorld1", Properties.Resources.ResourceManager);
        public string HelloWorld2 => langService.Get("HelloWorld2", Properties.Resources.ResourceManager);
        public string HelloWorld3 => langService.Get("HelloWorld3", Properties.Resources.ResourceManager);
        public string HelloWorld4 => langService.Get("HelloWorld4", Properties.Resources.ResourceManager);
        public string HelloWorld5 => langService.Get("HelloWorld5", Properties.Resources.ResourceManager);
        public string HelloWorld6 => langService.Get("HelloWorld6", Properties.Resources.ResourceManager);
        public string HelloWorld7 => langService.Get("HelloWorld7", Properties.Resources.ResourceManager);

        public ObservableCollection<string> Cultures { get; } = new ObservableCollection<string>();

        private string _SelectedItem;

        public string SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (SetProperty(ref _SelectedItem, value))
                {
                    Properties.Settings.Default.SelectedCulture = value;
                    Properties.Settings.Default.Save();
                    langService.SetCulture(value);
                    RaiseLangTextChanged();
                }

            }
        }

        private void RaiseLangTextChanged()
        {
            OnPropertyChanged(nameof(HelloWorld));
            OnPropertyChanged(nameof(HelloWorld1));
            OnPropertyChanged(nameof(HelloWorld2));
            OnPropertyChanged(nameof(HelloWorld3));
            OnPropertyChanged(nameof(HelloWorld4));
            OnPropertyChanged(nameof(HelloWorld5));
            OnPropertyChanged(nameof(HelloWorld6));
            OnPropertyChanged(nameof(HelloWorld7));
            // Diğer metinler için de benzer şekilde OnPropertyChanged çağrılabilir
        }

        private readonly ILangService langService;

        public UILanguageViewModel(ILangService langService)
        {
            this.langService = langService;
            EnsureDefaultCultures();
            LoadCultures();      // ItemsSource için yükleme
            LoadSelected();      // Başlangıçta seçim
        }

        private void LoadCultures()
        {
            var cultureList = Properties.Settings.Default.SupportedCultures;
            if (cultureList == null) return;

            Cultures.Clear();
            foreach (var culture in cultureList)
                Cultures.Add(culture);
        }

        private void LoadSelected()
        {
            var selected = Properties.Settings.Default.SelectedCulture;
            if (!string.IsNullOrEmpty(selected) && Cultures.Contains(selected))
                SelectedItem = selected;
        }
        private void EnsureDefaultCultures()
        {
            var cultures = Properties.Settings.Default.SupportedCultures;
            if (cultures == null)
            {
                cultures = new StringCollection();
                Properties.Settings.Default.SupportedCultures = cultures; // Referansı atıyoruz (tek seferlik)
            }

            if (!cultures.Contains("en-US"))
                cultures.Add("en-US");

            if (!cultures.Contains("tr-TR"))
                cultures.Add("tr-TR");
            if (!cultures.Contains("it-IT"))
                cultures.Add("it-IT");
            if (!cultures.Contains("ru-RU"))
                cultures.Add("ru-RU");
            if (!cultures.Contains("sr-SR"))
                cultures.Add("sr-SR");
            if (!cultures.Contains("hun-HUN"))
                cultures.Add("hun-HUN");
            Properties.Settings.Default.Save(); // Değişiklikleri kalıcı yap
        }
    }
}
