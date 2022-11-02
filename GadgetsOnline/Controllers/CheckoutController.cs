using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace GadgetsOnline.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderProcessing _orderProcessing;
        public CheckoutController(IOrderProcessing orderProcessing)
        {
            _orderProcessing = orderProcessing;
        }
        //OrderProcessing orderProcessing;
        private IOrderProcessing GetOrderProcess()
        {
            return _orderProcessing;
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
            /* Added by CTA: This updated method might require the parameters to be re-organized */
            TryUpdateModelAsync(order);
            try
            {
                order.Username = "Anonymous";
                order.OrderDate = DateTime.Now;
                bool result = GetOrderProcess().ProcessOrder(order, this.HttpContext);
                return RedirectToAction("Complete", new
                {
                id = order.OrderId
                }

                );
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