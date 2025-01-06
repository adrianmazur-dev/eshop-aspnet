using EShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.ViewComponents
{
    public class CatalogsViewComponent : ViewComponent
    {
        private readonly ICatalogService _catalogService;

        public CatalogsViewComponent(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string viewName = "Default")
        {
            var catalogs = await _catalogService.GetAllAsync();
            return View(viewName, catalogs);
        }
    }
}
