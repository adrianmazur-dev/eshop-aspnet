using EShop.Core.Interfaces.Services;
using EShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ICatalogItemService _catalogItemService;

        public CatalogController(ICatalogService catalogService, ICatalogItemService catalogItemService)
        {
            _catalogService = catalogService;
            _catalogItemService = catalogItemService;
        }

        public async Task<IActionResult> Index(CatalogFilterViewModel filter)
        {
            var items = await _catalogItemService.GetAllAsync();
            var catalogs = await _catalogService.GetAllAsync();

            if (!string.IsNullOrEmpty(filter.SearchName))
            {
                items = items.Where(i => i.Name.Contains(filter.SearchName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (filter.CatalogIds.Count > 0)
            {
                items = items.Where(i => filter.CatalogIds.Contains(i.CatalogId)).ToList();
            }

            if (filter.MinPrice.HasValue)
            {
                items = items.Where(i => i.Price >= filter.MinPrice.Value).ToList();
            }

            if (filter.MaxPrice.HasValue)
            {
                items = items.Where(i => i.Price <= filter.MaxPrice.Value).ToList();
            }

            filter.Items = items.ToList();
            ViewData["Catalogs"] = catalogs;
            return View(filter);
        }
    }
}
