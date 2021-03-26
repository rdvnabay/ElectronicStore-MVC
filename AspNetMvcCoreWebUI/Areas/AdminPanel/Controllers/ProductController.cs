using AspNetMvcCoreWebUI.Areas.AdminPanel.Models;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        IImageService _imageService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService,
            IImageService imageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _imageService = imageService;
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
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product, List<IFormFile> files)
        {

            if (product == null)
            {
                return View(product);
            }
            if (files == null)
            {
                return View(product);
            }
            _productService.Add(product);
            int productId = product.Id;

            foreach (var file in files)
            {
                var extention = Path.GetExtension(file.FileName);
                var fileName = string.Format($"{DateTime.Now.Ticks}{extention}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\panel\\img", fileName);
                var images = new List<Image>
                {
                  new Image{Name=fileName, ProductId=productId}
                };
                foreach (var image in images)
                {
                    _imageService.Add(image);
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }

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
                //product.Image = randomName;
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
