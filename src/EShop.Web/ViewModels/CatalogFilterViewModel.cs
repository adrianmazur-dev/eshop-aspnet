using EShop.Core.Entities;

namespace EShop.Web.ViewModels
{
    public class CatalogFilterViewModel
    {
        public string SearchName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<int> CatalogIds { get; set; } = [];
        public List<CatalogItem> Items { get; set; } = [];
    }
}
