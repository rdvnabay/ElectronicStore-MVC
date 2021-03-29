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
        private IOrderDetailService _orderItemService;
        private ICartSessionService _cartSessionService;
        private IContactService _contactService;
        public OrderController(
            ICartSessionService cartSessionService,
            IOrderService orderService,
            IOrderDetailService orderItemService,
            IContactService contactService)
        {
            _cartSessionService = cartSessionService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _contactService = contactService;
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
                Cart = _cartSessionService.GetCart(),
                Contact=_contactService.GetById(2).Data
                
            };
            return View(model);
        }

        [HttpPost] 
        public IActionResult Checkout(OrderViewModel orderViewModel)
        {
            var contact = orderViewModel.Contact;
            _contactService.Add(contact);

            
            return RedirectToAction("Index","Home");
        }
    }
}
