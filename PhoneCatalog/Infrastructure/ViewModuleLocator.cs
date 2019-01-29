using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using PhoneCatalog.ViewModel;

namespace PhoneCatalog.Infrastructure
{
    class ViewModuleLocator
    {
        public MainViewModel MainViewModel { get; set; }

        public ViewModuleLocator()
        {
            MainViewModel = new StandardKernel(new Module()).Get<MainViewModel>();
        }
    }
}
