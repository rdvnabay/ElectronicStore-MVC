using AspNetMvcCoreWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.ViewComponents
{
    public class CartSummary:ViewComponent
    {
        private ICartSessionService _cartSessionService;
        public CartSummary(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = _cartSessionService.GetCart();
            return View(model);
        }
    }
}
