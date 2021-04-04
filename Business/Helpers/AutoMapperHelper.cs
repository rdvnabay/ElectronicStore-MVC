using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Panel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Product, AddProductDto>().ReverseMap()
                .ForMember(p=>p.Id,opt=>opt.MapFrom(pdto=>pdto.Id));

            //CreateMap<ProductDetail, AddProductDetailDto>().ReverseMap()
            //       .ForMember(pd => pd.Id, opt => opt.MapFrom(pdto => pdto.Id));
        }
    }
}
