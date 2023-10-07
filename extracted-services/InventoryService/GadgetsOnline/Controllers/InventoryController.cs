using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;
using GadgetsOnline.Services;
using Microsoft.AspNetCore.Http;
using GadgetsOnline.DTO;
using System.Text.Json;

namespace GadgetsOnline.Controllers
{
    
    public class InventoryController : ControllerBase
    {

        [Route("/")]
        public IActionResult HealthCheck()
        {
            return Ok();
        }

        [Route("Inventory/HealthCheck2")]
        public IActionResult HealthCheck2()
        {
            return Ok();
        }

        [Route("GetBestSellers_6da88c34")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult GetBestSellers_6da88c34([FromBody] dynamic endpointContainer)
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
                int count = 0;
                if (!Object.ReferenceEquals(null, methodContainer))
                    count = Convert.ToInt32( methodContainer.GetProperty("count").ToString());
         

                return Ok(DTOHelper.GetDTOProductList(myInstance.GetBestSellers(count)));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("GetAllCategories_e3b0c442")]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult GetAllCategories_e3b0c442Wrapper([FromBody] dynamic endpointContainer)
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
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("GetAllProductsInCategory_473287f8")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult GetAllProductsInCategory_473287f8Wrapper([FromBody] dynamic endpointContainer)
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
                string category = string.Empty;
                if (!Object.ReferenceEquals(null, methodContainer))
                    category = Convert.ToInt32(methodContainer.GetProperty("category").ToString());


                return Ok(DTOHelper.GetDTOProductList(myInstance.GetAllProductsInCategory(category)));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("GetProductById_6da88c34")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult GetProductById_6da88c34Wrapper([FromBody] dynamic endpointContainer)
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
                int id = 0;
                if (!Object.ReferenceEquals(null, methodContainer))
                    id = Convert.ToInt32(methodContainer.GetProperty("id").ToString());

             
                return Ok(DTOHelper.GetDTOProduct(myInstance.GetProductById(id)));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [Route("GetProductNameById_6da88c34")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult GetProductNameById_6da88c34Wrapper([FromBody] dynamic endpointContainer)
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
                int id = 0;
                if (!Object.ReferenceEquals(null, methodContainer))
                    id = Convert.ToInt32(methodContainer.GetProperty("id").ToString());


                
               
                return Ok(myInstance.GetProductNameById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }
    }
}