using AspNetMvcCoreWebUI.Areas.AdminPanel.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class ProductController : Controller
    {
        #region Dependency Injection
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        #endregion

        //Methods
        #region Index
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model.Data);
        }
        #endregion 

        #region Add
        public IActionResult Add()
        {
            var model = new ProductCategoryListModel
            {
                Categories = _categoryService.GetAll().Data
        };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile file)
        {
            if (product == null)
            {
                return View(product);
            }
            if (file == null)
            {
                return View(product);
            }

            var extention = Path.GetExtension(file.FileName);
            var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");
            product.Image = randomName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\panel\\img", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _productService.Add(product);
            //TODO: Alert Message
            /*
            var msg = new AlertMessage()
            {
                Message = $"{product.Name} isimli ürün eklendi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);
            */
            return RedirectToAction("Index", "Product");
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            var model = _productService.GetById(id);
            return View(model.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile file)
        {
            if (file == null)
            {
                return View();
            }
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");
                product.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\panel\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            _productService.Update(product);
            return View();
        }
        #endregion

        #region Detail
        public IActionResult Detail()
        {
            return View();
        }
        #endregion

        #region Delete 
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            var model = _productService.GetById(productId);
            if (model != null)
            {
                _productService.Delete(model.Data);
                return RedirectToAction("Index", "Product");
            }

            return View();
        }
        #endregion
    }
}
