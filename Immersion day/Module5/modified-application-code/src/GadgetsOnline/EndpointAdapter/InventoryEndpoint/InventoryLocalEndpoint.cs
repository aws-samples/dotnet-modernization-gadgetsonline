using GadgetsOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;

namespace GadgetsOnline.EndpointAdapter
{
    public class InventoryLocalEndpoint : IInventoryEndpoint
    {
        private readonly Inventory originalInstance;
        public InventoryLocalEndpoint()
        {
            originalInstance = new Inventory();
        }

        public List<Product> GetBestSellers(int count)
        {
            return originalInstance.GetBestSellers(count);
        }

        public List<Category> GetAllCategories()
        {
            return originalInstance.GetAllCategories();
        }

        public List<Product> GetAllProductsInCategory(string category)
        {
            return originalInstance.GetAllProductsInCategory(category);
        }

        public Product GetProductById(int id)
        {
            return originalInstance.GetProductById(id);
        }

        public string GetProductNameById(int id)
        {
            return originalInstance.GetProductNameById(id);
        }
    }
}