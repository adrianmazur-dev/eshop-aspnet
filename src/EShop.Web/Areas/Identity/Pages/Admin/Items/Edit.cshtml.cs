using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Areas.Identity.Pages.Admin.Items
{
    public class EditModel : PageModel
    {
        private readonly ICatalogItemService _catalogItemService;

        public EditModel(ICatalogItemService catalogItemService)
        {
            _catalogItemService = catalogItemService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Item Name")]
            public string Name { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Price")]
            public decimal Price { get; set; }

            [Required]
            [Display(Name = "Catalog")]
            public int CatalogId { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Load catalogs for the dropdown
            var catalogs = await _catalogItemService.GetAllAsync();
            ViewData["Catalogs"] = new SelectList(catalogs, "Id", "Name");

            var item = await _catalogItemService.GetByIdAsync(id);
            if (item is null)
            {
                return RedirectToPage("./Index");
            }

            Input = new InputModel
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CatalogId = item.CatalogId
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var item = await _catalogItemService.GetByIdAsync(id);
            if (item is null)
            {
                return RedirectToPage("./Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            item.Name = Input.Name;
            item.Description = Input.Description;
            item.Price = Input.Price;
            item.CatalogId = Input.CatalogId;

            await _catalogItemService.UpdateAsync(item);

            return RedirectToPage("./Index");
        }
    }
}
