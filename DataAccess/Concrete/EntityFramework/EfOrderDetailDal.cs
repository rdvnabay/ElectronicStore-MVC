using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, ElectronicShopDbContext>, IOrderDetailDal
    {
        public List<UserOrderListDto> GetOrderList(int orderId)
        {
            using (var context = new ElectronicShopDbContext())
            {
                var result = from o in context.Orders
                             join od in context.OrderDetails
                             on o.Id equals od.OrderId
                             join p in context.Products
                             on od.ProductId equals p.Id
                             where o.Id == orderId
                             select new UserOrderListDto
                             {
                                 OrderId=o.Id,
                                 OrderDate=o.OrderDate,
                                 Name=p.Name,
                                 Quantity=od.Quantity,
                                 Price=od.Price
                            };

                           return result.ToList();
              
        }
    }
}
    //return context.Orders
    //      .Where(o => o.UserId == userId)
    //      .Include(o => o.OrderDetails)
    //      .ThenInclude(o => o.Product)
    //      .FirstOrDefault();
}