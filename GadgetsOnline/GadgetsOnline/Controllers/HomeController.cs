using GadgetsOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetsOnline.Controllers
{
    public class HomeController : Controller
    {
        Inventory inventory;
        public ActionResult Index()
        {
            inventory = new Inventory();
          
            var products = inventory.GetBestSellers(6);
            return View(products);
        }

        public ActionResult About()
        {
            inventory = new Inventory();
            string serverName = inventory.GetServerName();
            ViewBag.ServerName = serverName;
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}