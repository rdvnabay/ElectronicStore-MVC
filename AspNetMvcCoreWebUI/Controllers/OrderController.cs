using AspNetMvcCoreWebUI.Models;
using AspNetMvcCoreWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class OrderController : Controller
    {
        #region Dependency Injection
        private ICartSessionService _cartSessionService;
        public OrderController(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            var model = new OrderViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }

        [HttpPost] 
        public IActionResult Checkout(string model)
        {
            return View();
        }
    }
}
