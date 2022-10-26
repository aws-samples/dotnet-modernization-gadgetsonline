using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using System.Linq.Expressions;

namespace GadgetsOnline.Services
{
    public class OrderProcessing
    {
        GadgetsOnlineEntities store = new GadgetsOnlineEntities();
        internal bool ProcessOrder(Order order, HttpContextBase httpContext)
        {
            //store.Orders.Add(order);
            //store.SaveChanges();
            //Process the order
            var cart = ShoppingCart.GetCart(httpContext);
            
            SaveOrder(order);

            cart.CreateOrder(order);
            return true;
        }

        private void SaveOrder(Order order)
        {
            try
            {
                List<Cart> cartItems = ShoppingCart.CartItems;
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                int orderId = 0;
                
                foreach (Cart cart in cartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ProductId = cart.ProductId;
                    Inventory inventory = new Inventory();
                    Product product = inventory.GetProductById(cart.ProductId);
                    // Hard coding the quantity as the focus is on interfacing with Babelfish endpoint
                    orderDetail.Quantity = 1;
                    orderDetail.UnitPrice = product.Price;

                    orderDetails.Add(orderDetail);
                }


                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["GadgetsOnlineEntities"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = con;
                        cmd.CommandText = "InsertOrders";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@OrderId", SqlDbType.Int).Direction = ParameterDirection.Output;
                        //  cmd.Parameters[@"OrderId"].Direction = ParameterDirection.Output;

                        //Set SqlParameter
                        SqlParameter param1 = new SqlParameter
                        {
                            ParameterName = "@OrderDate", //Parameter name defined in stored procedure
                            SqlDbType = SqlDbType.DateTime, //Data Type of Parameter
                            Value = order.OrderDate.Date, //Value passes to the paramtere
                            Direction = ParameterDirection.Input //Specify the parameter as input
                        };
                        //  cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(CreateSqlParameter("Username", order.Username));
                        cmd.Parameters.Add(CreateSqlParameter("FirstName", order.FirstName));
                        cmd.Parameters.Add(CreateSqlParameter("LastName", order.LastName));
                        cmd.Parameters.Add(CreateSqlParameter("Address", order.Address));
                        cmd.Parameters.Add(CreateSqlParameter("City", order.City));
                        cmd.Parameters.Add(CreateSqlParameter("State", order.State));
                        cmd.Parameters.Add(CreateSqlParameter("PostalCode", order.PostalCode));
                        cmd.Parameters.Add(CreateSqlParameter("Country", order.Country));
                        cmd.Parameters.Add(CreateSqlParameter("Phone", order.Phone));
                        cmd.Parameters.Add(CreateSqlParameter("Email", order.Email));

                        SqlParameter param12 = new SqlParameter
                        {
                            ParameterName = "@Total", //Parameter name defined in stored procedure
                            SqlDbType = SqlDbType.Decimal, //Data Type of Parameter
                            Value = order.Total, //Value passes to the paramtere
                            Direction = ParameterDirection.Input //Specify the parameter as input
                        };
                        cmd.Parameters.Add(param12);

                        con.Open();
                        cmd.ExecuteNonQuery();
                       orderId = (int)cmd.Parameters["@OrderId"].Value;
                    }


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        // Insert Order details
                        foreach (OrderDetail orderDetail in orderDetails)
                        {
                            cmd.Parameters.Add(CreateIntSqlParameter("@OrderId", orderId));
                            cmd.Parameters.Add(CreateIntSqlParameter("@ProductId", orderDetail.ProductId));
                            cmd.Parameters.Add(CreateIntSqlParameter("Quantity", orderDetail.Quantity));
                            cmd.Parameters.Add(CreateIntSqlParameter("UnitPrice", (int) orderDetail.UnitPrice));
                        }

                        cmd.Connection = con;
                        cmd.CommandText = "InsertOrders_Detail";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        // return productCategory;
                    }
                    con.Close();
                }
               
            }
            catch (Exception ex)
            {
                // write exceptions to log file
                // for debugging; eating the exception... throw ex;
            }
        }

        private SqlParameter CreateIntSqlParameter(string parameterName, int value)
        {
            SqlParameter param1 = new SqlParameter
            {
                ParameterName = parameterName, //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.Int, //Data Type of Parameter
                Value = value, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            };

            return param1;
        }


        private SqlParameter CreateSqlParameter(string parameterName, string value)
        {
            SqlParameter param1 = new SqlParameter
            {
                ParameterName = parameterName, //Parameter name defined in stored procedure
                SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                Value = value, //Value passes to the paramtere
                Direction = ParameterDirection.Input //Specify the parameter as input
            };

            return param1;
        }

    }
}