using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Base.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : ObserrvableObject;
        void SetMainViewModel<TViewModel>() where TViewModel : ObserrvableObject;
    }

}
