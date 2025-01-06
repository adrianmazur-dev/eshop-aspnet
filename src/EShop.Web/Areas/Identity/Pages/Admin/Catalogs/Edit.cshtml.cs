using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Areas.Identity.Pages.Admin.Catalogs
{
    public class EditModel : PageModel
    {
        private readonly ICatalogService _catalogService;

        public EditModel(ICatalogService catalogService)
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Load parent catalogs for the dropdown
            var catalogs = await _catalogService.GetAllAsync();
            ViewData["Catalogs"] = new SelectList(catalogs, "Id", "Name");

            var catalog = catalogs.FirstOrDefault(c => c.Id.Equals(id));
            if (catalog == null)
            {
                return RedirectToPage("./Index");
            }

            Input = new InputModel
            {
                Name = catalog.Name,
                Description = catalog.Description,
                ParentCatalogId = catalog.ParentCatalogId
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var catalog = await _catalogService.GetByIdAsync(id);
            if (catalog is null)
            {
                return RedirectToPage("./Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            catalog.Name = Input.Name;
            catalog.Description = Input.Description;
            catalog.ParentCatalogId = Input.ParentCatalogId;

            await _catalogService.UpdateAsync(catalog);

            return RedirectToPage("./Index");
        }
    }
}
