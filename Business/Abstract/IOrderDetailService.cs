using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        IResult Add(OrderDetail orderDetail);
        IDataResult<Order> GetOrderList(int userId);
    }
}
