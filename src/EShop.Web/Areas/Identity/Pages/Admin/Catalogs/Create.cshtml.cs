using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Areas.Identity.Pages.Admin.Catalogs
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogService _catalogService;

        public CreateModel(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Catalog Name")]
            public string Name { get; set; }

            [Display(Name = "Description")]
            public string? Description { get; set; }

            [Display(Name = "Parent Catalog")]
            public int? ParentCatalogId { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Load parent catalogs for the dropdown
            var catalogs = await _catalogService.GetAllAsync();
            ViewData["Catalogs"] = new SelectList(catalogs, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var catalog = new Catalog
            {
                Name = Input.Name,
                Description = Input.Description,
                ParentCatalogId = Input.ParentCatalogId
            };

            await _catalogService.AddAsync(catalog);

            return RedirectToPage("./Index");
        }
    }
}
