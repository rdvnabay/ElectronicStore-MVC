using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IDataResult<List<Order>> GetByUser(int userId);
    }
}
