using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        [Area("adminPanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
