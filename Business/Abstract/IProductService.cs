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
        IDataResult<Product> Get(int id);
        IDataResult<List<Product>> GetAll();
  

        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<List<Product>>GetSearchResult(string searchString);
        //IDataResult<Product> GetById(int productId);
        //IDataResult<List<Product>> GetAllByCategoryId(int id);
        //IDataResult<List<Product>> GetUnitePrice(decimal min, decimal max);
        //IDataResult<List<ProductDetailDto>> GetProductDetails();

    }
}
