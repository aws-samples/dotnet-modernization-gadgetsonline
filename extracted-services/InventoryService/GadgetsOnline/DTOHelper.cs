using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.DTO
{
    public static class DTOHelper
    {
        public static List<DTO_Product> GetDTOProductList(List<Product> products)
        {
            var dto_products = new List<DTO_Product>();

            foreach (var product in products)
            {
                var categoryDTO = new DTO_Category
                {
                    Name = product.Category.Name,
                    CategoryId = product.Category.CategoryId,
                    Description = product.Category.Description,
                };

                dto_products.Add(new DTO_Product
                {
                    Category = categoryDTO,
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    ProductId = product.ProductId,
                    ProductArtUrl = product.ProductArtUrl,
                });
            }

            return dto_products;
        }

        public static DTO_Product GetDTOProduct(Product product)
        {
            var categoryDTO = new DTO_Category
            {
                Name = product.Category.Name,
                CategoryId = product.Category.CategoryId,
                Description = product.Category.Description,
            };

            var dto_product = new DTO_Product
            {
                Category = categoryDTO,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                ProductArtUrl = product.ProductArtUrl,
                ProductId = product.ProductId,
            };
            return dto_product;
        }
    }
}
