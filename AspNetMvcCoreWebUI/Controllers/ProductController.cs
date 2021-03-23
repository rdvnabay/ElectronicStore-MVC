using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class ProductController : Controller
    {
        #region Dependency Injection
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        //Methods
        #region Index
        public IActionResult Index()
        {  
            return View(_productService.GetAll());
        }
        #endregion


        #region Detail
        public IActionResult Detail(int id)
        {
            var model = _productService.Get(id);
            return View(model.Data);
        }
        #endregion
    }
}
