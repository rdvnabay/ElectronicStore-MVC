using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            var model = _productService.GetAll().Data;
            return View(model);
        }
        #endregion
    }
}
