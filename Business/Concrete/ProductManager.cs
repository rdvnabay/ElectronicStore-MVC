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
using Entities.DTOs.Panel;
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
        IProductCategoryDal _productCategoryDal;
        ICategoryService _categoryService;
        public ProductManager(
            IProductDal productDal,
            IProductCategoryDal productCategoryDal,
            ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            _productCategoryDal = productCategoryDal;
        }
        #endregion


        //Methods
        #region Add
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameAlreadyExist(product.Name),
                  //CheckIfProductCountOfCategoryCorrect(product.CategoryId),
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

        #region GetProductsOfByCategory
        public IDataResult<List<Product>> GetProductsByCategory(string categoryName,int page, int pageSize)
        {
            //var data = _productDal.GetAll(p => p.ProductCategories.Select(c=>c.Category.Name.Contains(categoryName));
            //if (data != null)
            //{
            //    return new SuccessDataResult<List<Product>>(_productDal.GetProductsOfByCategory(categoryName, search, page, pageSize));
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetProductsByCategory(categoryName, page, pageSize));
        }
        #endregion


        public IDataResult<Product> GetProductDetails(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.GetProductDetails(productId));

        }

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
            //var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            //if (result > 10)
            //{
            //    new ErrorResult(Messages.CheckIfProductCountOfCategoryCorrect);
            //}
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

        public IDataResult<List<ProductListDto>> NewProducts()
        {
            return new SuccessDataResult<List<ProductListDto>>(_productDal.NewProducts());
        }

        public IDataResult<List<ProductListDto>> TopSelling()
        {
            return new SuccessDataResult<List<ProductListDto>>(_productDal.TopSelling());
        }

        public IDataResult<List<Product>> GetProductsAll(int page, int pageSize)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetProductsAll(page, pageSize));
        }

        public IResult AddProductCategory(ProductCategory productCategory)
        {
            _productCategoryDal.Add(productCategory);
            return new SuccessResult();
        }
        #endregion
    }
}
