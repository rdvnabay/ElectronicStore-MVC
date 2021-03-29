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
    }
}
