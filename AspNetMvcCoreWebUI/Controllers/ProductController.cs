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
        //[Route("products/{categoryId?}")]
        public IActionResult Index(int categoryId,int page=1)
        {
            const int pageSize = 3;

            return View(new ProductListViewModel()
            {
                Products = _productService.GetProductsOfByCategoryId(categoryId,page,pageSize).Data,
                PagingInfo = new PagingInfo
                {
                    CurrentCategoryId = categoryId,
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetAll().Data.Count
                }
            });
            //var model= _productService.GetProductsOfByCategoryId(categoryId);
            //return View(model.Data);
        }
        #endregion


        #region Detail
        public IActionResult Detail(int productId)
        {
            var product = _productService.GetProductDetails(productId).Data;
            var model = new ProductDetailsModel
            {
                Product = product
                //Images = product.Images.ToList(),
                //Categories=product.ProductCategories.Select(c=>c.Category).ToList()
            };
            return View(model); 
        }
        #endregion
    }
}
