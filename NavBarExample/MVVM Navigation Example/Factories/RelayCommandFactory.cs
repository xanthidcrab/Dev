using Autofac;
using MVVM_Base;
using MVVM_Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Navigation_Example.Factories
{
    public class RelayCommandFactory : IRelayCommandFactory
    {
        public ICommand Create(Action execute, Func<bool> canExecute = null)
        {
            return new RelayCommand(execute);
        }

      
    }
}
