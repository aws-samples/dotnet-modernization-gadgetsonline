using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.Services
{
    public class Inventory : IInventory
    {
        private readonly GadgetsOnlineEntities _gadgetsOnlineEntities;

        public Inventory(GadgetsOnlineEntities gadgetsOnlineEntities)
        {
            _gadgetsOnlineEntities = gadgetsOnlineEntities;
        }

        //GadgetsOnlineEntities store = new GadgetsOnlineEntities();

        public List<Product> GetBestSellers(int count)
        {
            return _gadgetsOnlineEntities.Products
                    .Take(count)
                    .ToList();
        }

        public List<Category> GetAllCategories()
        {
            return _gadgetsOnlineEntities.Categories.ToList();
        }

        public List<Product> GetAllProductsInCategory(string category)
        {
            return _gadgetsOnlineEntities.Products
                    .Where(p => p.Category.Name == category)
                    .ToList();
        }

        public Product GetProductById(int id)
        {
            return _gadgetsOnlineEntities.Products
                   .Where(p => p.ProductId == id)
                   .FirstOrDefault();
        }

        public string GetProductNameById(int id)
        {
            return _gadgetsOnlineEntities.Products
                   .Where(p => p.ProductId == id)
                   .FirstOrDefault().Name;
        }
    }
}