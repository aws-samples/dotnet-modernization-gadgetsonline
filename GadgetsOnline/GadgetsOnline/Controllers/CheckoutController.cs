using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetsOnline.Models;
using GadgetsOnline.Services;

namespace GadgetsOnline.Controllers
{
    public class CheckoutController : Controller
    {
        OrderProcessing orderProcessing;
        private OrderProcessing GetOrderProcess()
        {
            if (this.orderProcessing == null)
            {
                this.orderProcessing = new OrderProcessing();
            }
            return this.orderProcessing;
        }

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {

                order.Username = "Anonymous";
                order.OrderDate = DateTime.Now;

                bool result = GetOrderProcess().ProcessOrder(order, this.HttpContext);

                return RedirectToAction("Complete",
                    new { id = order.OrderId });
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            return View(id);
        }
    }
}