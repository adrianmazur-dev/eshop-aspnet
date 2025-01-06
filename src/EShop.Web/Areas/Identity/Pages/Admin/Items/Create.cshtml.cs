using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Areas.Identity.Pages.Admin.Items    
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogItemService _catalogItemService;
        private readonly ICatalogService _catalogService;

        public CreateModel(ICatalogItemService catalogItemService, ICatalogService catalogService)
        {
            _catalogItemService = catalogItemService;
            _catalogService = catalogService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Item Name")]
            public string Name { get; set; }

            [Display(Name = "Description")]
            public string? Description { get; set; }

            [Required]
            [Display(Name = "Price")]
            [Range(0.01, double.MaxValue, ErrorMessage = "The field Price must be a number.")]
            public decimal Price { get; set; }

            [Required]
            [Display(Name = "Catalog")]
            public int CatalogId { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Load catalogs for the dropdown
            var catalogs = await _catalogService.GetAllAsync();
            ViewData["Catalogs"] = new SelectList(catalogs, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var catalogs = await _catalogService.GetAllAsync();
                ViewData["Catalogs"] = new SelectList(catalogs, "Id", "Name");
                return Page();
            }

            var catalogItem = new CatalogItem
            {
                Name = Input.Name,
                Description = Input.Description,
                Price = Input.Price,
                CatalogId = Input.CatalogId
            };

            await _catalogItemService.AddAsync(catalogItem);

            return RedirectToPage("./Index");
        }
    }
}