using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {

        #region AddToCart
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.Id == product.Id);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine
            {
                Product = product,
                Quantity = 1
            });
        }
        #endregion

        #region List
        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }
        #endregion

        #region RemoveFromCart
        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.Id == productId));
        }
        #endregion

        public void RemoveFromCartAll(Cart cart)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault());
        }
    }
}
