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
    public class ProductController : Controller
    {
        #region Dependency Injection
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        public IActionResult Index()
        {
            var model=_productService.GetAll();
            return View(model.Data);
        }
        #region Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);
            return View();
        }
        #endregion

        public IActionResult Detail()
        {
            return View();
        }
    }
}
