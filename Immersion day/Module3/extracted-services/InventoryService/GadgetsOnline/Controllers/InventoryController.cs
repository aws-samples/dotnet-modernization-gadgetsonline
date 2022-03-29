using System;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;

namespace GadgetsOnline.Controllers
{
    [RoutePrefix ( "api/Inventory" )]
    public class InventoryController : ApiController
    {
        [Route("GetBestSellers_6da88c34")]
        [ResponseType(typeof(List<Product>))]
        [HttpPost]
        public IHttpActionResult GetBestSellers_6da88c34Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                Inventory myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                // Initialize the right constructor
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new Inventory();
                }

                // Retrieve Method parameters
                int count = methodContainer.count;
                return Ok(myInstance.GetBestSellers(count));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
        }

        [Route("GetAllCategories_e3b0c442")]
        [ResponseType(typeof(List<Category>))]
        [HttpPost]
        public IHttpActionResult GetAllCategories_e3b0c442Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                Inventory myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                // Initialize the right constructor
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new Inventory();
                }

                // Retrieve Method parameters
                return Ok(myInstance.GetAllCategories());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
        }

        [Route("GetAllProductsInCategory_473287f8")]
        [ResponseType(typeof(List<Product>))]
        [HttpPost]
        public IHttpActionResult GetAllProductsInCategory_473287f8Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                Inventory myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                // Initialize the right constructor
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new Inventory();
                }

                // Retrieve Method parameters
                string category = methodContainer.category;
                return Ok(myInstance.GetAllProductsInCategory(category));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
        }

        [Route("GetProductById_6da88c34")]
        [ResponseType(typeof(Product))]
        [HttpPost]
        public IHttpActionResult GetProductById_6da88c34Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                Inventory myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                // Initialize the right constructor
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new Inventory();
                }

                // Retrieve Method parameters
                int id = methodContainer.id;
                return Ok(myInstance.GetProductById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
        }

        [Route("GetProductNameById_6da88c34")]
        [ResponseType(typeof(string))]
        [HttpPost]
        public IHttpActionResult GetProductNameById_6da88c34Wrapper(dynamic endpointContainer)
        {
            try
            {
                dynamic ctorContainer = EndpointParamStore.GetConstructorContainer(endpointContainer);
                dynamic methodContainer = EndpointParamStore.GetMethodContainer(endpointContainer);
                Inventory myInstance = null;
                string ctorParamHash = EndpointParamStore.GetConstructorParamHash(ctorContainer);
                // Initialize the right constructor
                if (ctorParamHash.Equals("e3b0c442"))
                {
                    myInstance = new Inventory();
                }

                // Retrieve Method parameters
                int id = methodContainer.id;
                return Ok(myInstance.GetProductNameById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
        }
    }
}