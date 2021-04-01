using AspNetMvcCoreWebUI.Areas.AdminPanel.Models;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Panel;
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
        IProductDetailService _productDetailService;
        ICategoryService _categoryService;
        IImageService _imageService;

        public ProductController(
            IProductService productService,
            IProductDetailService productDetailService,
            ICategoryService categoryService,
            IImageService imageService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model, List<IFormFile> files)
        {
            if (model == null)
            {
                return View(model);
            }
            if (files == null)
            {
                return View(model);
            }
            _productService.Add(model.Product);
            _productDetailService.Add(model.ProductDetail);
            int productId = model.Product.Id;

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
        public async Task<IActionResult> Edit(Product product, IFormFile files)
        {
            if (files == null)
            {
                return View();
            }
            if (files != null)
            {
                var extention = Path.GetExtension(files.FileName);
                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");
                //product.Image = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\panel\\img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
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

        #region GetProductsByCategory
        public IActionResult Deneme(string categoryName)
        {
            ViewBag.Categories = _categoryService.GetAll().Data;
            var products = _productService.GetProductsByCategory(categoryName);
            return View(products.Data);
        }
        #endregion
    }
}
