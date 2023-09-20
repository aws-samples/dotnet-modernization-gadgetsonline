using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.DTO
{
    public class DTO_Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public DTO_Product Product { get; set; }
    }

    public class DTO_Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DTO_Product> Products { get; set; }
    }

    public class DTO_Order
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public List<DTO_OrderDetail> OrderDetails { get; set; }
    }

    public class DTO_OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DTO_Product Product { get; set; }
        public DTO_Order Order { get; set; }
    }

    public class DTO_Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductArtUrl { get; set; }
        public DTO_Category Category { get; set; }
        public List<DTO_OrderDetail> OrderDetails { get; set; }
    }
}
