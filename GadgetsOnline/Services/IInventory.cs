using GadgetsOnline.Models;
using System.Collections.Generic;

namespace GadgetsOnline.Services
{
    public interface IInventory
    {
        List<Category> GetAllCategories();
        List<Product> GetAllProductsInCategory(string category);
        List<Product> GetBestSellers(int count);
        Product GetProductById(int id);
        string GetProductNameById(int id);
    }
}