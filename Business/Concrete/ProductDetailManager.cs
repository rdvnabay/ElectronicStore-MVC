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
    public class ProductDetailManager : IProductDetailService
    {
        private IProductDetailDal _productDetailDal;
        public ProductDetailManager(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
        }
        public IDataResult<ProductDetail> Add(ProductDetail productDetail)
        {
            _productDetailDal.Add(productDetail);
            return new SuccessDataResult<ProductDetail>();
        }
    }
}
