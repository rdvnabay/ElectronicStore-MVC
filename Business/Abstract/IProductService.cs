using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Panel;
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
        IDataResult<List<ProductListDto>> TopSelling();
        IDataResult<List<ProductListDto>>NewProducts();
        IDataResult<List<Product>> GetProductsAll(int page, int pageSize);
        IDataResult<List<Product>> GetProductsByCategory(string categoryName,int page,int pageSize);
        IDataResult<Product> GetProductDetails(int productId);
        IResult AddProductCategory(ProductCategory productCategory);
    }
}
