using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, ElectronicShopDbContext>, IOrderDetailDal
    {
        public Order GetOrderList(int userId)
        {
            using (var context = new ElectronicShopDbContext())
            {
                return context.Orders
                      .Where(o => o.UserId == userId)
                      .Include(o => o.OrderDetails)
                      .ThenInclude(o => o.Product)
                      .FirstOrDefault();
            }
        }
    }
}
