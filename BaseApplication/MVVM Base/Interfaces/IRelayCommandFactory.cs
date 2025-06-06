using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Base.Interfaces
{
    public interface IRelayCommandFactory
    {
        ICommand Create(Action execute, Func<bool> canExecute = null);
    }
}
