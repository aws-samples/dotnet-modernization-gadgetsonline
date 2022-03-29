using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.Services
{
    public class Inventory
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();

        public List<Product> GetBestSellers(int count) 
        {
            return store.Products
                    .Take(count)
                    .ToList();                                            
        }

        public List<Category> GetAllCategories()
        {
            return store.Categories.ToList();
        }

        public List<Product> GetAllProductsInCategory(string category)
        {
            return store.Products
                    .Where(p => p.Category.Name == category)
                    .ToList();
        }

        public Product GetProductById(int id)
        {
            return store.Products
                   .Where(p => p.ProductId == id)
                   .FirstOrDefault();
        }

        internal string GetProductNameById(int id)
        {
            return store.Products
                   .Where(p => p.ProductId == id)
                   .FirstOrDefault().Name;
        }
    }
}