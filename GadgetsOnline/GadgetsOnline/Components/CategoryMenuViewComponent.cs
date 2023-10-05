    using GadgetsOnline.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GadgetsOnline.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        Inventory inventory;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            inventory = new Inventory();
            var categories = inventory.GetAllCategories();
            return View(categories);
        }
    }
}
