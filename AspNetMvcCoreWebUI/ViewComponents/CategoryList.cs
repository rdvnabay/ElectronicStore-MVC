using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categoryList = _categoryService.GetAll();
            return View(categoryList.Data);
        }
    }
}
