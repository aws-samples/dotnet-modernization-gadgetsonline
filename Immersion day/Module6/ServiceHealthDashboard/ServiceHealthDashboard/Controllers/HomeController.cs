using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net.Http;
using ServiceHealthDashboard.Models;

namespace ServiceHealthDashboard.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var isDatabaseAvailable = await IsDatabaseAvailableAsync();
            var isWebsiteAvailable = await IsWebsiteAvailableAsync();

            return View(new ServiceStatusViewModel { IsDatabaseAvailable = isDatabaseAvailable, IsWebsiteAvailable = isWebsiteAvailable });
        }

        private async Task<bool> IsDatabaseAvailableAsync()
        {
            var connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];

            using(var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    connection.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }                
            }
        }

        private async Task<bool> IsWebsiteAvailableAsync()
        {
            var url = ConfigurationManager.AppSettings["WebsiteUrl"];

            using(var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
        }        
    }
}