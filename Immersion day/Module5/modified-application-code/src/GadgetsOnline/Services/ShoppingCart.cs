using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.Services
{
    public class ShoppingCart
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
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

        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
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

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        /* TODO (by AWS Microservice Extractor for .NET) Exposing constructor as an endpoint is not supported */
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

        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
        public int GetCount()
        {
            int? count = (
                from cartItems in store.Carts
                where cartItems.CartId == ShoppingCartId
                select (int? )cartItems.Count).Sum();
            return count ?? 0;
        }

        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
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

        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
        public List<Cart> GetCartItems()
        {
            return store.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        /* TODO (by AWS Microservice Extractor for .NET) Exposing a method as an endpoint is currently only supported when the construction of the method invoking object could be detected to be in the same class by our current algorithm */
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