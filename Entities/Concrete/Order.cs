using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string PaymentType { get; set; }
        public string OrderStatus { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
