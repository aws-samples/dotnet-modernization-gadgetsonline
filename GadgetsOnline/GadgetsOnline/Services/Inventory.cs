using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.Services
{
    public class Inventory
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();

        static List<Product> products = new List<Product>();
        static List<Category> productCategory = new List<Category>();
        public List<Product> GetBestSellers(int count) 
        {
            // Get Products from database
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GadgetsOnlineEntities"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select [ProductId],[dbo].[Products].[CategoryId],[dbo].[Products].[Name],[Price],[ProductArtUrl],[dbo].[Categories].[Name] as CategoryName,[Description] from [dbo].[Products] Inner join [dbo].[Categories] on  Products.ProductId = Categories.CategoryId";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DataRow[] rows = dt.Select();
                  //  List<Product> result = new List<Product>();
                   
                    if (rows.Count() > 0)
                    {
                        foreach (DataRow row in rows)
                        {
                            Category category = new Category();
                            category.CategoryId = (int)row["CategoryId"];
                            category.Name = row["CategoryName"].ToString();
                            category.Description = row["Description"].ToString();
                            
                            Product product = new Product();
                            product.CategoryId = (int) row["CategoryId"];
                            product.ProductId = (int)row["ProductId"];
                            product.Name = row["Name"].ToString();
                            product.Price = (decimal) row["Price"];
                            product.ProductArtUrl = row["ProductArtUrl"].ToString();

                            product.Category = category;

                            products.Add(product);
                        }
                    }
                    con.Close();
                    return products;
                }
            }
        
            return store.Products
                    .Take(count)
                    .ToList();                                            
        }

        public List<Category> GetAllCategories()
        {
            if (productCategory.Count > 0) return productCategory;
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GadgetsOnlineEntities"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [dbo].[Categories]";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DataRow[] rows = dt.Select();
                   // List<Category> result = new List<Category>();

                    if (rows.Count() > 0)
                    {
                        foreach (DataRow row in rows)
                        {
                            Category category = new Category();
                            category.CategoryId = (int)row["CategoryId"];
                            category.Name = row["name"].ToString();
                            category.Description = row["description"].ToString();

                            productCategory.Add(category);
                        }
                    }
                    con.Close();
                    return productCategory;
                }
            }
        }

        public List<Product> GetAllProductsInCategory(string category)
        {
            // Find the category Id from name
            Category filtertedCategory = productCategory.Where(i => i.Name.Equals(category)).FirstOrDefault();

            //   List<Product> products = GetBestSellers(20);

            return products.Where(p => p.CategoryId == filtertedCategory.CategoryId)
                    .ToList();

            //return store.Products
            //        .Where(p => p.Category.Name == category)
            //        .ToList();
        }

        public Product GetProductById(int id)
        {
          


            return products
                  .Where(p => p.ProductId == id)
                  .FirstOrDefault();

            //return store.Products
            //       .Where(p => p.ProductId == id)
            //       .FirstOrDefault();
        }

        internal string GetProductNameById(int id)
        {
            return products
                   .Where(p => p.ProductId == id)
                   .FirstOrDefault().Name;
        }
    }
}