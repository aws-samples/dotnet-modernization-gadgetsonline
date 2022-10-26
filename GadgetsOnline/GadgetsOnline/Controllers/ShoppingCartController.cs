using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using GadgetsOnline.ViewModel;

namespace GadgetsOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        Inventory inventory;
        // GET: ShoppingCart
        public ActionResult Index()
        {
          List<Cart> cartItems = ShoppingCart.CartItems;
            
          inventory = new Inventory();
           
           decimal productPrice = 0;
            
            foreach (Cart cart1 in cartItems)
            {
                Product product = inventory.GetProductById(cart1.ProductId);
                cart1.Product = product;
                productPrice = productPrice + product.Price; 
            }
           
           ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

              //  (List<Cart>) HttpContext.Session["CartItems"];

           // var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems, 
                CartTotal = productPrice
                // cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(id);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            int itemCount = cart.RemoveFromCart(id);
            inventory = new Inventory();
            var productName = inventory.GetProductNameById(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel{Message = Server.HtmlEncode(productName) + " has been removed from your shopping cart.", CartTotal = cart.GetTotal(), CartCount = cart.GetCount(), ItemCount = itemCount, DeleteId = id};
            return RedirectToAction("Index");
        }
    }
}