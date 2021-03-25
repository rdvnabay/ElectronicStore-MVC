using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Models.Paging
{
    public class ProductListViewModel
    {
        public PagingInfo PagingInfo { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
    }
}
