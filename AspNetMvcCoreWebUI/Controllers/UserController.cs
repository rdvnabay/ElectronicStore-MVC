using AspNetMvcCoreWebUI.Models.OrderModel;
using Business.Abstract;
using Entities.DTOs;
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
        private IOrderService _orderService;
        public UserController(
            IOrderDetailService orderDetailService,
            IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult OrderDetail(int orderId)
        {
            //var userId = 1;
            var model = _orderDetailService.GetOrderList(orderId);
            if (model == null)
            {
                return View();
            }
            return View(model.Data);
        }

        public IActionResult Orders()
        {
            var userId = 1;
            var model = _orderService.GetByUser(userId);
            if (model == null)
            {
                return View();
            }
            return View(model.Data);
        }
    }
}
