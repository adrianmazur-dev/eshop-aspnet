using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using EShop.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Web.Areas.Identity.Pages.Admin.Catalogs
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private ICatalogService _catalogService;

        public IndexModel(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public ICollection<Catalog> Catalogs = [];

        public async Task<IActionResult> OnGetAsync()
        {
            var items = await _catalogService.GetAllAsync();
            
            Catalogs = items.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _catalogService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
