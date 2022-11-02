using System;
using System.Collections.Generic;
using System.Linq;
using GadgetsOnline.Models;
using Microsoft.AspNetCore.Http;

namespace GadgetsOnline.Services
{
    public class OrderProcessing : IOrderProcessing
    {
        private readonly GadgetsOnlineEntities _gadgetsOnlineEntities;
        private readonly IShoppingCart _shoppingCart;

        public OrderProcessing(GadgetsOnlineEntities gadgetsOnlineEntities, IShoppingCart shoppingCart)
        {
            _gadgetsOnlineEntities = gadgetsOnlineEntities;
            _shoppingCart = shoppingCart;
        }

        //GadgetsOnlineEntities store = new GadgetsOnlineEntities();

        public bool ProcessOrder(Order order, HttpContext httpContext)
        {
            _gadgetsOnlineEntities.Orders.Add(order);
            _gadgetsOnlineEntities.SaveChanges();
            //Process the order
            //var cart = ShoppingCart.GetCart(httpContext); //OLD
            var cart = _shoppingCart.GetCart(httpContext);
            cart.CreateOrder(order);
            return true;
        }
    }
}