using AspNetMvcCoreWebUI.Models;
using AspNetMvcCoreWebUI.Services;
using Business.Abstract;
using Entities.Concrete;
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
        private IOrderService _orderService;
        private ICartSessionService _cartSessionService;
        public OrderController(
            ICartSessionService cartSessionService,
            IOrderService orderService)
        {
            _cartSessionService = cartSessionService;
            _orderService = orderService;
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
        public IActionResult Checkout(OrderViewModel orderViewModel)
        {
            var order = new Order
            {
                FirstName = orderViewModel.FirstName,
                LastName = orderViewModel.LastName,
                Email=orderViewModel.Email,
                Phone=orderViewModel.Phone,
                Town=orderViewModel.Town,
                City=orderViewModel.City,
                Address=orderViewModel.Address
            };
            _orderService.Add(order);
            return RedirectToAction("Index","Home");
        }
    }
}
