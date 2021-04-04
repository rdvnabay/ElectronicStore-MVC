using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public List<Image> Images { get; set; }
    }
}
