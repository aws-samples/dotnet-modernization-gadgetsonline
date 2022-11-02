using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace GadgetsOnline.Controllers
{
    public class StoreController : Controller
    {
        private readonly IInventory _inventory;
        private readonly IShoppingCart _shoppingCart;

        public StoreController(IInventory inventory, IShoppingCart shoppingCart)
        {
            _inventory = inventory;
            _shoppingCart = shoppingCart;
        }

        //Inventory inventory;
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse(string category)
        {
            //inventory = new Inventory();
            var productModel = _inventory.GetAllProductsInCategory(category);
            return View(productModel);
        }

        public ActionResult Details(int id)
        {
            //inventory = new Inventory();
            var album = _inventory.GetProductById(id);
            return View(album);
        }
    }
}