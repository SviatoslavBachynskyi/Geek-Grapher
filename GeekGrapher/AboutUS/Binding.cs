using AutoMapper;
using Ninject;
using Ninject.Modules;

namespace GeekGrapher.AboutUS
{
    class Binding : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().To<AboutUsMapper>().InSingletonScope();
        }
    }
}
