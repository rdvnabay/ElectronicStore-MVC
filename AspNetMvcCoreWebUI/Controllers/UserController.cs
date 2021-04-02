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
            var model = _orderDetailService.GetOrderList(userId);
            if (model == null)
            {
                return View();
            }
            return View(model.Data);
        }
    }
}
