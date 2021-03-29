using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.ViewComponents
{
    public class ProductCountOfCategory:ViewComponent
    {
        #region Dependency Injection
        private ICategoryService _categoryService;
        public ProductCountOfCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model=_categoryService.ProductCountOfCategory();
            return View(model.Data);
        }
        #endregion
    }
}
