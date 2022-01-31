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