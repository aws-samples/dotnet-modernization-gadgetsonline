using GadgetsOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.EndpointAdapter
{
    public interface IInventoryEndpoint
    {
        List<Product> GetBestSellers(int count);
        List<Category> GetAllCategories();
        List<Product> GetAllProductsInCategory(string category);
        Product GetProductById(int id);
        string GetProductNameById(int id);
    }
}