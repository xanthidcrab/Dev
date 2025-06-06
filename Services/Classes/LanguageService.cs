using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class LanguageService : ILangService
    {
        public void SetCulture(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
        }

        public string Get(string key, ResourceManager resourceManager)
        {
            return resourceManager.GetString(key);
        }
    }
}
