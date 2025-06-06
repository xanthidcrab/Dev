using Autofac;
using MVVM_Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Base;
namespace MVVM_Navigation_Example.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IComponentContext _context;
        public ViewModelFactory(IComponentContext context)
        {
            _context = context;
        }

        public T CreateViewModel<T>() where T : ObserrvableObject
        {
            return _context.Resolve<T>();
        }
    }
}
