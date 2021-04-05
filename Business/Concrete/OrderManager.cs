using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        #region Dependency Injection
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        #endregion

        #region Add
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult();
;        }
        #endregion

        #region GetByUser
        public IDataResult<List<Order>> GetByUser(int userId)
        {
           return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.UserId == userId));
        }
        #endregion
    }
}
