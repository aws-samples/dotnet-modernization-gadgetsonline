using GadgetsOnline.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GadgetsOnline.EndpointAdapter;

namespace GadgetsOnline.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        Inventory inventory;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            inventory = (Inventory)InventoryEndpointFactory.GetEndpointAdapter();
            var categories = inventory.GetAllCategories();
            return View(categories);
        }
    }
}