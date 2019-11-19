using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekGrapher.AboutUsCore;

namespace GeekGrapher.AboutUS
{
    class AboutUsMapper : Mapper
    {
        public AboutUsMapper():
            base(new MapperConfiguration(
                        (cfg) =>
                        {
                            cfg.CreateMap<Author, AuthorViewModel>();
                            cfg.CreateMap<AuthorViewModel, Author>();

                            cfg.CreateMap<AboutUsModel, AboutUsViewModel>();
                            cfg.CreateMap<AboutUsViewModel, AboutUsModel>();
                        }))
        {

        }
    }
}
