using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TreeViewDeneme.Services.Interfaces;

namespace TreeViewDeneme.Services
{
    public class LanguageService : ILanguageService
    {
        public void ChangeLanguage<TContentModel>(TContentModel model)
        {
            Type modelType = typeof(TContentModel);
            var properties = modelType.GetProperties();

            foreach (var item in properties)
            {
                string resourceKey = item.Name;
                string resourceValue = Properties.Resources.ResourceManager.GetString(resourceKey);
                if (!string.IsNullOrEmpty(resourceValue) && item.CanWrite && item.PropertyType == typeof(string))
                {
                    item.SetValue(model, resourceValue);
                }
            }
        }
    }
}
