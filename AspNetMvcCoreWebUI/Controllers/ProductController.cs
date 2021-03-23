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
            var model = _productService.GetAll();
            return View(model.Data);
        }

        [Route("products/{categoryId?}")]
        public IActionResult Index(int categoryId)
        {
           var model= _productService.GetProductsOfByCategoryId(categoryId);
            return View(model.Data);
        }
        #endregion


        #region Detail
        public IActionResult Detail(int id)
        {
            var model = _productService.GetById(id);
            return View(model.Data);
        }
        #endregion
    }
}
