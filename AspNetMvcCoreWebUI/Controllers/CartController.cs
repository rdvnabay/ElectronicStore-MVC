using AspNetMvcCoreWebUI.Services;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreWebUI.Controllers
{
    public class CartController : Controller
    {
        #region Dependency Injection
        private IProductService _productService;
        private ICartService _cartService;
        private ICartSessionService _cartSessionService;
        public CartController(
            IProductService productService,
            ICartService cartService,
            ICartSessionService cartSessionService
            )
        {
            _productService = productService;
            _cartService = cartService;
            _cartSessionService = cartSessionService;
        }
        #endregion

        #region AddToCart
        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded.Data);
            _cartSessionService.SetCart(cart);
            return Json(cart);
            //return RedirectToAction("Index", "Home");
        }
        #endregion

        #region RemoveFromCart
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
