using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs.Panel;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ElectronicShopDbContext>, IProductDal
    {
       
        #region GetProductDetails
        public Product GetProductDetails(int productId)
        {

            using (var context = new ElectronicShopDbContext())
            {
                return context.Products
                    .Where(p => p.Id == productId)
                    .Include(p => p.Images)
                    .Include(p=>p.ProductCategories)
                    .ThenInclude(p=>p.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string categoryName)
        {
            using (ElectronicShopDbContext context = new ElectronicShopDbContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(categoryName))
                {
                    products = products
                    .Include(p => p.ProductCategories)
                    .ThenInclude(p => p.Category)
                    .Where(pc => pc.ProductCategories.Any(c => c.Category.Name == categoryName));
                }
                return products.ToList();
                    
            }
        }

        //var result = from p in context.Products
        //             join i in context.Images
        //             on p.Id equals i.ProductId
        //             join c in context.Categories
        //             on p.CategoryId equals c.Id
        //             where p.Id == productId
        //             select new ProductDetailDto
        //             {
        //                 Id = p.Id,
        //                 Name = p.Name,
        //                 UnitPrice = p.UnitPrice,
        //                 UnitsInStock = p.UnitsInStock,
        //                 ShortDescription=p.ShortDescription,
        //                 Description=p.Description,
        //                 CategoryName=c.Name,
        //                 Images = new List<Image>
        //                 {
        //                     new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id}
        //                     //new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id},
        //                     //new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id},
        //                     //new Image{ Id=i.Id,Name=i.Name, ProductId=p.Id}
        //                 }
        //             };
        //return result.AsQueryable().Where(p=>p.Id==productId).FirstOrDefault();
        //return result.FirstOrDefault();


        #endregion

        #region GetProductsOfByCategoryId
        public List<Product> GetProductsOfByCategoryId(int categoryId, int page, int pageSize)
        {
            using (var context = new ElectronicShopDbContext())
            {
                var products = context.Products.AsQueryable();
                if (categoryId > 0)
                {
                    //products = products.Where(p => p.CategoryId == categoryId);
                    return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<ProductListDto> NewProducts()
        {
            using (var context=new ElectronicShopDbContext())
            {
                var result = from p in context.Products
                             join pd in context.ProductDetails
                             on p.Id equals pd.Id
                             where pd.IsNewProduct==true
                             select new ProductListDto
                             {
                                 Id=p.Id,
                                 Name = p.Name,
                                 Price=p.UnitPrice,
                             };
                return result.ToList();
            }
        }

        public List<ProductListDto> TopSelling()
        {
            using (var context = new ElectronicShopDbContext())
            {
                var result = from p in context.Products
                             join pd in context.ProductDetails
                             on p.Id equals pd.Id
                             where pd.IsTopSelling == true
                             select new ProductListDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Price = p.UnitPrice,
                             };
                return result.ToList();
            }
        }
        #endregion

    }
}
