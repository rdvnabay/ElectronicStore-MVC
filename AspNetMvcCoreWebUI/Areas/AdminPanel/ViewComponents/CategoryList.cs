using AspNetMvcCoreWebUI.Areas.AdminPanel.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke(/*int categoryId*/)
        {
            var categoryList = new ProductCategoryListModel
            {
                Categories = _categoryService.GetAll().Data
                //CategoryId = categoryId
            };
               
            return View(categoryList);
        }
    }
}

