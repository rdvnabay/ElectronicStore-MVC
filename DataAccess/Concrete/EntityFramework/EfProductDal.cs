using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ElectronicShopDbContext>, IProductDal
    {

        #region GetProductDetails
        public ProductDetailDto GetProductDetails(int productId)
        {

            using (ElectronicShopDbContext context = new ElectronicShopDbContext())
            {
                //return context.Products
                //    .Where(p => p.Id == productId)
                //    .Include(p => p.Images)
                //    .FirstOrDefault();
                var result = from p in context.Products
                             join i in context.Images
                             on p.Id equals i.ProductId
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             where p.Id == productId
                             select new ProductDetailDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock,
                                 ShortDescription=p.ShortDescription,
                                 Description=p.Description,
                                 CategoryName=c.Name,
                                 Images = new List<Image>
                                 {
                                     new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id},
                                     new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id},
                                     new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id},
                                     new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id}
                                 }
                             };
                //return result.AsQueryable().Where(p=>p.Id==productId).FirstOrDefault();
                return result.FirstOrDefault();
            }
        }
        #endregion

        #region GetProductsOfByCategoryId
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
        #endregion

    }
}
