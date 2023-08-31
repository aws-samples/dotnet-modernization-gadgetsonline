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
        Inventory inventory;
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        /* Added by CTA: This attribute is not available anymore. An alternative is using ViewComponents:
Sample:

public class SampleViewComponent : ViewComponent
    {
        private readonly InjectedService _injectedService;

        public SampleViewComponent (InjectedService injectedService)
        {
            _injectedService = injectedService;
        }


       public IViewComponentResult Invoke(int parameter)
        {
            var object = _injectedService.SampleFunction(parameter);
        // No name is specified, returns the view SampleView (same name as component)
            return View(object);
        }
    }

Then use this to call the view component from any view:

    @await Component.InvokeAsync("SampleView", new { parameter = ""})

//https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-3.1 */
//        [ChildActionOnly]
//        public ActionResult CategoryMenu()
//        {
//            inventory = new Inventory();
//            var categories = inventory.GetAllCategories();
//            return PartialView(categories);
//        }

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