using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        #region Dependency Injection
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,
            ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        #endregion


        //Methods
        #region Add
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameAlreadyExist(product.Name),
                  CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                  CheckIfCategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        #endregion

        #region Edit
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }
        #endregion

        #region Get
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }
        #endregion

        #region GetAll
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());

        }
        #endregion
 
        #region GetSearchResult
        public IDataResult<List<Product>> GetSearchResult(string searchString)
        {
            var data=_productDal.GetAll(p=>p.Name.Contains(searchString));
            if (data==null)
            {
                return new ErrorDataResult<List<Product>>(Messages.NotFoundProduct);
            }
            return new SuccessDataResult<List<Product>>(data);
        }
        #endregion

        #region Delete 
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }
        #endregion

        #region GetProductsOfByCategoryId
        public IDataResult<List<Product>> GetProductsOfByCategoryId(int categoryId,int page, int pageSize)
        {
            var data=_productDal.GetAll(p => p.CategoryId == categoryId);
            if (data!=null)
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetProductsOfByCategoryId(categoryId,page,pageSize));
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }
        #endregion

        //Business Rules Methods
        #region Business Rules 
        private IResult CheckIfProductNameAlreadyExist(string productName)
        {
            var result = _productDal.GetAll(p => p.Name == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result > 10)
            {
                new ErrorResult(Messages.CheckIfProductCountOfCategoryCorrect);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
