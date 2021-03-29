using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.ViewComponents
{
    public class UserNavi:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
