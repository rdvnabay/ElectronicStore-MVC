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
        public IResult Add(ProductDetail productDetail)
        {
            _productDetailDal.Add(productDetail);
            return new SuccessResult();
        }

        public IDataResult<ProductDetail> GetById(int id)
        {
            return new SuccessDataResult<ProductDetail>(_productDetailDal.Get(pd => pd.Id == id));
        }

        public IResult Update(ProductDetail productDetail)
        {
            _productDetailDal.Update(productDetail);
            return new SuccessResult();
        }
    }
}
