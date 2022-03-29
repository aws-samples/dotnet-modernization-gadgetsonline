using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.Services
{
    public class OrderProcessing
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
        internal bool ProcessOrder(Order order, HttpContextBase httpContext)
        {
            store.Orders.Add(order);
            store.SaveChanges();
            //Process the order
            var cart = ShoppingCart.GetCart(httpContext);
            cart.CreateOrder(order);
            return true;
        }
    }
}