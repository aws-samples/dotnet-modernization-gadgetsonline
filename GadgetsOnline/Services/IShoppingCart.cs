using GadgetsOnline.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GadgetsOnline.Services
{
    public interface IShoppingCart
    {
        void AddToCart(int id);
        ShoppingCart GetCart(HttpContext context);
        string GetCartId(HttpContext context);
        List<Cart> GetCartItems();
        int GetCount();
        decimal GetTotal();
    }
}