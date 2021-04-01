using AspNetMvcCoreWebUI.Models.OrderModel;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class UserController : Controller
    {
        private IOrderDetailService _orderDetailService;
        public UserController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var userId = 2;
            var order = _orderDetailService.GetOrderList(userId).Data;
            if (order == null)
            {
                return View();
            }
            var model = new UserOrdersViewModel
            {
                Orders =    order.OrderDetails.Select(p => p.Order).ToList(),
                Products = order.OrderDetails.Select(p => p.Product).ToList()
            };
            return View(model);
        }
    }
}
