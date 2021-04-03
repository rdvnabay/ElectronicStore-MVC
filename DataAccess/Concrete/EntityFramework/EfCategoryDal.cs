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
            /*
             select pc.CategoryId,count(pc.ProductId) from Categories c
inner join ProductCategories pc
on c.Id=pc.CategoryId
group by pc.CategoryId
             */
            using (var context = new ElectronicShopDbContext())
            {
                var result = from c in context.Categories
                             join pc in context.ProductCategories
                             on c.Id equals pc.CategoryId
                             group pc by new { pc.CategoryId, pc.Category.Name } into pc
                             select new ProducCountOfCategoryDto
                             {
                                 CategoryId = pc.Key.CategoryId,
                                 CategoryName = pc.Key.Name,
                                 ProductCount = pc.Count()
                             };
                return result.ToList();
            }
        }
    }
}
