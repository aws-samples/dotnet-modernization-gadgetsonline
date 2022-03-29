using System;
using Newtonsoft.Json;
//using System.Web.Http.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace GadgetsOnline.Controllers
{
    /* Added by CTA: RoutePrefix attribute is no longer supported */
    //[RoutePrefix("api/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [Route("GetBestSellers_6da88c34")]
        [Produces(typeof(List<Product>))]
        [HttpPost]
        public IActionResult GetBestSellers_6da88c34Wrapper(dynamic endpointContainer)
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
                return StatusCode(500);
            }
        }

        [Route("GetAllCategories_e3b0c442")]
        [Produces(typeof(List<Category>))]
        [HttpPost]
        public IActionResult GetAllCategories_e3b0c442Wrapper(dynamic endpointContainer)
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
                return StatusCode(500);
            }
        }

        [Route("GetAllProductsInCategory_473287f8")]
        [Produces(typeof(List<Product>))]
        [HttpPost]
        public IActionResult GetAllProductsInCategory_473287f8Wrapper(dynamic endpointContainer)
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
                return  StatusCode(500);
            }
        }

        [Route("GetProductById_6da88c34")]
        [Produces(typeof(Product))]
        [HttpPost]
        public IActionResult GetProductById_6da88c34Wrapper(dynamic endpointContainer)
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
                return  StatusCode(500);
            }
        }

        [Route("GetProductNameById_6da88c34")]
        [Produces(typeof(string))]
        [HttpPost]
        public IActionResult GetProductNameById_6da88c34Wrapper(dynamic endpointContainer)
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
                return StatusCode(500);
            }
        }
    }
}