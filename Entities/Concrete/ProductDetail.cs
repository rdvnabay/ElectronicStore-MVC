using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProductDetail:IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsTopSelling { get; set; }
        public bool IsNewProduct { get; set; }
        public bool IsHome { get; set; }

        public Product Product { get; set; }
    }
}
