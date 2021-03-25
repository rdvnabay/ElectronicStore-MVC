using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.Models
{
    public class ProductCategoryListModel
    {
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
