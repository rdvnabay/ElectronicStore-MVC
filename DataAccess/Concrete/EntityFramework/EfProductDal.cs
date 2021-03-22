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
    }
}
