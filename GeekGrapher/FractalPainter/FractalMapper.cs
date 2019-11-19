using AutoMapper;
using GeekGrapher.FractalCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.FractalPainter
{
    class FractalMapper : Mapper
    {
        public FractalMapper()
            :base(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FractalModel, FractalPainterViewModel>()
                .ForMember(vm => vm._palette, opt => opt.MapFrom(m => m._palette.Select(s => new ColorWrapper() { Value = s }).ToArray()));
                cfg.CreateMap<FractalPainterViewModel, FractalModel>()
                .ForMember(m => m._palette, opt => opt.MapFrom(vm => vm._palette.Select(s => s.Value).ToArray()));
            }))
        {

        }
    }
}
