using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Models
{
    public class OrderViewModel
    {
        public Contact Contact { get; set; }
        public Cart Cart { get; set; }
        //public Order Order { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }


    }
}
