using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using GadgetsOnline.EndpointAdapter;

namespace GadgetsOnline.Controllers
{
    public class StoreController : Controller
    {
        IInventoryEndpoint inventory;
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            inventory = InventoryEndpointFactory.GetEndpointAdapter();
            var categories = inventory.GetAllCategories();
            return PartialView(categories);
        }

        public ActionResult Browse(string category)
        {
            inventory = InventoryEndpointFactory.GetEndpointAdapter();
            var productModel = inventory.GetAllProductsInCategory(category);
            return View(productModel);
        }

        public ActionResult Details(int id)
        {
            inventory = InventoryEndpointFactory.GetEndpointAdapter();
            var album = inventory.GetProductById(id);
            return View(album);
        }
    }
}