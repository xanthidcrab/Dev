using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewDeneme.Services.Interfaces
{
    public interface ILanguageService
    {
        void ChangeLanguage<TContentModel>(TContentModel model);
    }
}
