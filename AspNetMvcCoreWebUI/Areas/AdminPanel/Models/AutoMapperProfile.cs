using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, AddProductDto>().ReverseMap();
            //.ForMember(p => p.Id, opt => opt.MapFrom(pdto => pdto.Id));
            CreateMap<ProductDetail, AddProductDto>().ReverseMap();
            //.ForMember(pd => pd.Id, opt => opt.MapFrom(pdto => pdto.Id));
            CreateMap<ProductCategory, AddProductDto>().ReverseMap();
            //.ForMember(pc => pc.CategoryId, opt => opt.MapFrom(pdto => pdto.CategoryId));
        }
    }
}
