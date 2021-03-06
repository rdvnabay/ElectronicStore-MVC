using AspNetMvcCoreWebUI.Models;
using AspNetMvcCoreWebUI.Models.OrderModel;
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
        private ICartService _cartService;
        public OrderController(
            ICartSessionService cartSessionService,
            IOrderService orderService,
            IOrderDetailService orderItemService,
            IContactService contactService,
            ICartService cartService)
        {
            _cartSessionService = cartSessionService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _contactService = contactService;
            _cartService = cartService;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region Checkout
        public IActionResult Contact()
        {
            var model = new ContactViewModel
            {
                Cart = _cartSessionService.GetCart(),
                Contact = new Contact()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if (contactViewModel == null)
            {
                return View(contactViewModel);
            }
            contactViewModel.Contact.UserId = 1;
            var contact = contactViewModel.Contact;
            _contactService.Add(contact);
            return RedirectToAction("Checkout", "Order");
        }
        #endregion
        #region Checkout
        public IActionResult Checkout()
        {
            var model = new CartInfoViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(CartInfoViewModel cartInfoViewModel)
        {
            var orderItems = _cartSessionService.GetCart();
            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderStatus = "onaylandı";
            order.UserId = 1;
            order.PaymentType = "Credit Cart";
            _orderService.Add(order);
            foreach (var item in orderItems.CartLines)
            {
                var orderdetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = item.Product.Id,
                    Price=item.Product.UnitPrice,
                    Quantity=item.Quantity
                };

                _orderItemService.Add(orderdetail);
            }
            _cartService.RemoveFromCartAll(orderItems);
            _cartSessionService.SetCart(orderItems);
            return RedirectToAction("Success", "Order");  
        }
        #endregion


        #region Success
        public IActionResult Success()
        {
            return View();
        }
        #endregion
    }
}
