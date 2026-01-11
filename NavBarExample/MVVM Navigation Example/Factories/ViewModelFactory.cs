using Autofac;
using MVVM_Base;
using MVVM_Base.Interfaces;
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
