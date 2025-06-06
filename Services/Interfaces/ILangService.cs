using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILangService
    {
        string Get(string key, ResourceManager resourceManager); // Örn: "SaveButton"
        void SetCulture(string cultureName); // "en-US", "tr-TR"

    }
}
