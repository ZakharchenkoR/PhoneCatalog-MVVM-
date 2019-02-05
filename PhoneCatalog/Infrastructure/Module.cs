using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCatalog.Model;

namespace PhoneCatalog.Infrastructure
{
    class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<ISaver>().To<JSONSaver>();
            Bind<ILoader>().To<JSONLoader>();
            Bind<ISaverStyle>().To<JSONSaveStyle>();
            Bind<ILoaderStyle>().To<JSONLoadStyle>();
        }
    }
}
