using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using EShop.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Areas.Identity.Pages.Admin.Product
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private ICatalogItemService _catalogItemService;

        public IndexModel(ICatalogItemService catalogItemService)
        {
            _catalogItemService = catalogItemService;
        }

        public ICollection<CatalogItem> CatalogItems = [];

        public async Task<IActionResult> OnGet()
        {
            var items = await _catalogItemService.GetAllAsync();
            
            CatalogItems = items.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _catalogItemService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
