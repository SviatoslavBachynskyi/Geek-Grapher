using AutoMapper;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalPainter
{
    class Binding : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().To<FractalMapper>();
        }
    }
}
