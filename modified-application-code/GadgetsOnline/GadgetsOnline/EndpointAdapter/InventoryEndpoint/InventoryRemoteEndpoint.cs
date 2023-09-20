using GadgetsOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using System.Net.Http;

namespace GadgetsOnline.EndpointAdapter
{
    public class InventoryRemoteEndpoint : IInventoryEndpoint
    {
        private string endpointAddress;
        private static readonly string endpointPrefix = "";
        private readonly dynamic ctorParams;
        public InventoryRemoteEndpoint(string remoteEndpoint)
        {
            endpointAddress = remoteEndpoint;
            ctorParams = EndpointParamStore.NewContainer();
            EndpointParamStore.SetConstructorParamHash(ctorParams, "e3b0c442");
        }

        public List<Product> GetBestSellers(int count)
        {
            return GetBestSellersRemote("GetBestSellers_6da88c34", count);
        }

        public List<Product> GetBestSellersRemote(string endpointSuffix, int count)
        {
            try
            {
                dynamic methodParams = EndpointParamStore.NewContainer();
                methodParams.count = count;
                HttpClient client = EndpointUtils.initializeClientWithJsonMedia(endpointAddress);
                HttpResponseMessage response = EndpointUtils.PostAndGetResponse<dynamic>(client, endpointPrefix, endpointSuffix, EndpointParamStore.NewEndpointContainer(ctorParams, methodParams));
                
                //Dictionary<string,string> methodParams1 = new  Dictionary<string,string>();
                //Dictionary<string, int> ctorParams1 = new Dictionary<string, int>();

                //methodParams1["C_PARAMS_HASH"] = "e3b0c442";
                //methodParams1["M_PARAMS"] = "6";

                //HttpResponseMessage response = EndpointUtils.PostAndGetResponse<dynamic>(client, endpointPrefix, endpointSuffix, methodParams1);
                return EndpointUtils.ReadResponse<List<Product>>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Category> GetAllCategories()
        {
            return GetAllCategoriesRemote("GetAllCategories_e3b0c442");
        }

        public List<Category> GetAllCategoriesRemote(string endpointSuffix)
        {
            try
            {
                dynamic methodParams = EndpointParamStore.NewContainer();
                HttpClient client = EndpointUtils.initializeClientWithJsonMedia(endpointAddress);
                HttpResponseMessage response = EndpointUtils.PostAndGetResponse<dynamic>(client, endpointPrefix, endpointSuffix, EndpointParamStore.NewEndpointContainer(ctorParams, methodParams));
                return EndpointUtils.ReadResponse<List<Category>>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Product> GetAllProductsInCategory(string category)
        {
            return GetAllProductsInCategoryRemote("GetAllProductsInCategory_473287f8", category);
        }

        public List<Product> GetAllProductsInCategoryRemote(string endpointSuffix, string category)
        {
            try
            {
                dynamic methodParams = EndpointParamStore.NewContainer();
                methodParams.category = category;
                HttpClient client = EndpointUtils.initializeClientWithJsonMedia(endpointAddress);
                HttpResponseMessage response = EndpointUtils.PostAndGetResponse<dynamic>(client, endpointPrefix, endpointSuffix, EndpointParamStore.NewEndpointContainer(ctorParams, methodParams));
                return EndpointUtils.ReadResponse<List<Product>>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product GetProductById(int id)
        {
            return GetProductByIdRemote("GetProductById_6da88c34", id);
        }

        public Product GetProductByIdRemote(string endpointSuffix, int id)
        {
            try
            {
                dynamic methodParams = EndpointParamStore.NewContainer();
                methodParams.id = id;
                HttpClient client = EndpointUtils.initializeClientWithJsonMedia(endpointAddress);
                HttpResponseMessage response = EndpointUtils.PostAndGetResponse<dynamic>(client, endpointPrefix, endpointSuffix, EndpointParamStore.NewEndpointContainer(ctorParams, methodParams));
                return EndpointUtils.ReadResponse<Product>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetProductNameById(int id)
        {
            return GetProductNameByIdRemote("GetProductNameById_6da88c34", id);
        }

        public string GetProductNameByIdRemote(string endpointSuffix, int id)
        {
            try
            {
                dynamic methodParams = EndpointParamStore.NewContainer();
                methodParams.id = id;
                HttpClient client = EndpointUtils.initializeClientWithJsonMedia(endpointAddress);
                HttpResponseMessage response = EndpointUtils.PostAndGetResponse<dynamic>(client, endpointPrefix, endpointSuffix, EndpointParamStore.NewEndpointContainer(ctorParams, methodParams));
                return EndpointUtils.ReadResponse<string>(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }


}