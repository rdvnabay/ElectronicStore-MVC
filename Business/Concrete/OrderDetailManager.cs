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
    public class OrderDetailManager : IOrderDetailService
    {
        private IOrderDetailDal _orderItemDal;
        public OrderDetailManager(IOrderDetailDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }
        public IResult Add(OrderDetail orderDetail)
        {
            _orderItemDal.Add(orderDetail);
            return new SuccessResult();
        }
    }
}
