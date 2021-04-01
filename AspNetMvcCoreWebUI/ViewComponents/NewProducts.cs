using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.ViewComponents
{
    public class NewProducts:ViewComponent
    {
        private IProductService _productService;
        public NewProducts(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var model= _productService.NewProducts();
            return View(model.Data);
        }
    }
}
