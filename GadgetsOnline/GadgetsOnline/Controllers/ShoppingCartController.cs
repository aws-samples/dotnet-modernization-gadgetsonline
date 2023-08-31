using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using GadgetsOnline.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace GadgetsOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        Inventory inventory;
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel{CartItems = cart.GetCartItems(), CartTotal = cart.GetTotal()};
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
            var results = new ShoppingCartRemoveViewModel{Message = HtmlEncoder.Default.Encode(productName) + " has been removed from your shopping cart.", CartTotal = cart.GetTotal(), CartCount = cart.GetCount(), ItemCount = itemCount, DeleteId = id};
            return RedirectToAction("Index");
        }
    }
}