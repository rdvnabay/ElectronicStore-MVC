using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class CategoryController : Controller
    {
        #region Dependency Injection
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var model=_categoryService.GetAll();
            return View(model.Data);
        }
        #endregion

        #region Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return RedirectToAction("Index","Category");
        }
        #endregion

        #region Detail
        public IActionResult Detail()
        {
            return View();
        }

        #endregion

        #region Edit
        public IActionResult Edit()
        {
            return View();
        }
        #endregion

        #region Remove
        [HttpPost]
        public IActionResult Remove(int categoryId)
        {
            var model=_categoryService.GetById(categoryId);
            if (model==null)
            {
                return View();
            }
            _categoryService.Delete(model.Data);
            return RedirectToAction("Index","Category");
        }
        #endregion  
    }
}
