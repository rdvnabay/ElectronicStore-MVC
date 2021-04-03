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
        private IAuthService _authService;
        public HomeController(
            IProductService productService,
            IAuthService authService)

        {
            _productService = productService;
            _authService = authService;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            
            return View(_productService.GetAll().Data);
        }
        #endregion
    }
}
