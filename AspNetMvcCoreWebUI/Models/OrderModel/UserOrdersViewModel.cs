using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Models.OrderModel
{
    public class UserOrdersViewModel
    {
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }
}
