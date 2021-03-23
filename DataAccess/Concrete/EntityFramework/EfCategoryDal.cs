using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ElectronicShopDbContext>, ICategoryDal
    {
        public List<ProducCountOfCategoryDto> ProductCountOfCategory()
        {
            using (var context = new ElectronicShopDbContext())
            {
                var result = from c in context.Categories
                             join p in context.Products
                             on c.Id equals p.CategoryId
                             group p by new { c.Id, c.Name } into cp
                             select new ProducCountOfCategoryDto
                             {
                                 CategoryId = cp.Key.Id,
                                 CategoryName = cp.Key.Name,
                                 ProductCount=cp.Count() 
                             };
                return result.ToList();
            }
        }  
    }
}
