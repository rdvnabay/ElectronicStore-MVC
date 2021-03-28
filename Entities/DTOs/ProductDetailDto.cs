using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public List<Image> Images { get; set; }
    }
}
