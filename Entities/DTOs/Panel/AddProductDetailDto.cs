using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.Panel
{
   public class AddProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; }
        public bool IsTopSelling { get; set; }
        public bool IsNewProduct { get; set; }
        public bool IsHome { get; set; }
    }
}
