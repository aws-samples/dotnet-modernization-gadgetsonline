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
        private readonly IInventory _inventory;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IInventory inventory, IShoppingCart shoppingCart)
        {
            _inventory = inventory;
            _shoppingCart = shoppingCart;
        }

        //Inventory inventory;
        // GET: ShoppingCart
        public ActionResult Index()
        {
            //xxxx var cart = ShoppingCart.GetCart(this.HttpContext); //OLD
            var cart = _shoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel{CartItems = cart.GetCartItems(), CartTotal = cart.GetTotal()};
            // Return the view
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            //xxxx var cart = ShoppingCart.GetCart(this.HttpContext); //OLD
            var cart = _shoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(id);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            //xxxx var cart = ShoppingCart.GetCart(this.HttpContext); //OLD
            var cart = _shoppingCart.GetCart(this.HttpContext);
            int itemCount = cart.RemoveFromCart(id);
            //xxxx inventory = new Inventory(); //OLD
            //xxxx var productName = inventory.GetProductNameById(id); //OLD
            var productName = _inventory.GetProductNameById(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel{Message = HtmlEncoder.Default.Encode(productName) + " has been removed from your shopping cart.", CartTotal = cart.GetTotal(), CartCount = cart.GetCount(), ItemCount = itemCount, DeleteId = id};
            return RedirectToAction("Index");
        }
    }
}