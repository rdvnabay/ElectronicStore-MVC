using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ElectronicShopDbContext>, IProductDal
    {
        #region GetProductDetails
        public List<ProductDetailDto> GetProductDetails()
        {
            using (ElectronicShopDbContext context = new ElectronicShopDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 UnitsInStock = p.UnitsInStock,
                                 CategoryName = c.Name
                             };
                return result.ToList();
            }
        }
        #endregion

        public List<Product> GetProductsOfByCategoryId(int categoryId, int page, int pageSize)
        {
            using (var context = new ElectronicShopDbContext())
            {
                var products = context.Products.AsQueryable();
                if (categoryId > 0)
                {
                    products = products.Where(p => p.CategoryId == categoryId);
                    return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
