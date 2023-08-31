using System;
using System.Collections.Generic;
using System.Linq;
using GadgetsOnline.Models;
using Microsoft.AspNetCore.Http;

namespace GadgetsOnline.Services
{
    public class ShoppingCart
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContext context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        internal int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail{ProductId = item.ProductId, OrderId = order.OrderId, UnitPrice = item.Product.Price, Quantity = item.Count};
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Product.Price);
                store.OrderDetails.Add(orderDetail);
            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            // Save the order
            store.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        private void EmptyCart()
        {
            var cartItems = store.Carts.Where(cart => cart.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                store.Carts.Remove(cartItem);
            }

            // Save changes
            store.SaveChanges();
        }

        public string GetCartId(HttpContext context)
        {
            //xxxx if (context.Session[CartSessionKey] == null) //OLD
            if (context.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    //xxxx context.Session[CartSessionKey] = context.User.Identity.Name; //OLD
                    context.Session.SetString(CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    //xxxx context.Session[CartSessionKey] = tempCartId.ToString(); //OLD
                    context.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }

            //xxxx return context.Session[CartSessionKey].ToString(); //OLD
            return context.Session.GetString(CartSessionKey);
        }


        public void AddToCart(int id)
        {
            var cartItem = store.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart{ProductId = id, CartId = ShoppingCartId, Count = 1, DateCreated = DateTime.Now};
                store.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }

            // Save changes
            store.SaveChanges();
        }

        public int GetCount()
        {
            int? count = (
                from cartItems in store.Carts
                where cartItems.CartId == ShoppingCartId
                select (int? )cartItems.Count).Sum();
            return count ?? 0;
        }

        internal int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = store.Carts.Single(cart => cart.CartId == ShoppingCartId && cart.ProductId == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    store.Carts.Remove(cartItem);
                }

                // Save changes
                store.SaveChanges();
            }

            return itemCount;
        }

        public List<Cart> GetCartItems()
        {
            return store.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
            decimal? total = (
                from cartItems in store.Carts
                where cartItems.CartId == ShoppingCartId
                select (int? )cartItems.Count * cartItems.Product.Price).Sum();
            return total ?? decimal.Zero;
        }
    }
}