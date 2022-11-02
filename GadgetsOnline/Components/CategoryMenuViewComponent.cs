using GadgetsOnline.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GadgetsOnline.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IInventory _inventory;

        public CategoryMenuViewComponent(IInventory inventory)
        {
            _inventory = inventory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _inventory.GetAllCategories();
            return View(categories);
        }
    }
}
