using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Models.OrderModel
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public Cart Cart { get; set; }
    }
}
