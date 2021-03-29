using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetAll();
  

        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<List<Product>>GetSearchResult(string searchString);
        IDataResult<List<Product>> GetProductsOfByCategoryId(int categoryId,int page,int pageSize);
        IDataResult<Product> GetProductDetails(int productId);
        IDataResult<List<Product>> GetProductsByCategory(string categoryName);
        //IDataResult<Product> GetById(int productId);
        //IDataResult<List<Product>> GetAllByCategoryId(int id);
        //IDataResult<List<Product>> GetUnitePrice(decimal min, decimal max);

    }
}
