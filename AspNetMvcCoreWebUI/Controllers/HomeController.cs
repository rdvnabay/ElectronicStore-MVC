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
        public IActionResult Index()
        {
            var model=_productService.GetAll();
            return View(model.Data);
        }
        #endregion
    }
}
