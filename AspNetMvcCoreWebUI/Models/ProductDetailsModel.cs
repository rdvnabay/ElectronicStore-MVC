using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Image> Images { get; set; }
    }
}
