using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetsOnline.Models;
using GadgetsOnline.Services;

namespace GadgetsOnline.Controllers
{
    public class StoreController : Controller
    {
        Inventory inventory;       

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {         
            inventory = new Inventory();
            var categories = inventory.GetAllCategories();
            return PartialView(categories);
        }

        public ActionResult Browse(string category)
        {
            inventory = new Inventory();         
            var productModel = inventory.GetAllProductsInCategory(category);
            return View(productModel);
        }

        public ActionResult Details(int id)
        {
            inventory = new Inventory();            
            var album = inventory.GetProductById(id);
            return View(album);
        }
    }
}