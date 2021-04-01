using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.ViewComponents
{
    public class TopSelling:ViewComponent
    {
        private IProductService _productService;
        public TopSelling(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _productService.TopSelling();
            return View(model.Data);
        }
    }
}
