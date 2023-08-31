using System;
using System.Collections.Generic;
using System.Linq;
using GadgetsOnline.Models;
using Microsoft.AspNetCore.Http;

namespace GadgetsOnline.Services
{
    public class OrderProcessing
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
        internal bool ProcessOrder(Order order, HttpContext httpContext)
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