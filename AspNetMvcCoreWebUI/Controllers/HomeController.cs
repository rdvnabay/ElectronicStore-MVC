using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency Injection
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region Index
        public IActionResult Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                var model=_productService.GetSearchResult(searchString);
                return View(model.Data);
            }

            return View(_productService.GetAll().Data);
        }
        #endregion
    }
}
