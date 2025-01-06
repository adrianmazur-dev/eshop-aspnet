using EShop.Core.Interfaces.Services;
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

        public async Task<IActionResult> Index()
        {
            var items = await _catalogItemService.GetAllAsync();
            return View(items);
        }
    }
}
