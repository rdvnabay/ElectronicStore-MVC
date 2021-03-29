using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Product GetProductDetails(int productId);
        List<Product> GetProductsOfByCategoryId(int categoryId, int page, int pageSize);
        List<Product> GetProductsByCategory(string categoryName);
    }
}
