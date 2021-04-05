using AspNetMvcCoreWebUI.Models;
using AspNetMvcCoreWebUI.Models.Paging;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class ProductController : Controller
    {
        #region Dependency Injection
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        //Methods
        #region Index
        public IActionResult Index(string categoryName, int page=1)
        {
            const int pageSize = 4;
            if (string.IsNullOrEmpty(categoryName))
            {
                return View(new ProductListViewModel()
                {
                    Products = _productService.GetProductsAll(page, pageSize).Data,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = _productService.GetAll().Data.Count
                    }
                });
            }

            return View(new ProductListViewModel()
            {
                Products = _productService.GetProductsByCategory(categoryName,page,pageSize).Data,
                PagingInfo = new PagingInfo
                {
                    CurrentCategoryName = categoryName,
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetAll().Data.Where(c=>c.Name==categoryName).Count()
                }
            });
        }
        #endregion


        #region Detail
        public IActionResult Detail(int productId)
        {
            var product = _productService.GetProductDetails(productId).Data;
            var model = new ProductDetailsModel
            {
                Product = product,
                Images = product.Images.ToList(),
                Categories = product.ProductCategories.Select(c => c.Category).ToList()
            };
            return View(model); 
        }
        #endregion
    }
}
