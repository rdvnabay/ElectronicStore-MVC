using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Panel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Product GetProductDetails(int productId);
        List<Product> GetProductsByCategory(string categoryName, int page, int pageSize);
        List<ProductListDto> NewProducts();
        List<ProductListDto> TopSelling();
        List<Product> GetProductsAll(int page, int pageSize);
        //void AddProductDetail(AddProductDetailDto product);
    }
}
