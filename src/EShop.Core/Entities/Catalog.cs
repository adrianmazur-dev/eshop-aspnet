using System.ComponentModel.DataAnnotations.Schema;
using EShop.Core.Interfaces;

namespace EShop.Core.Entities;

public class Catalog : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? ParentCatalogId { get; set; }

    [ForeignKey(nameof(ParentCatalogId))]
    public Catalog? ParentCatalog { get; set; } = null!;

    public ICollection<Catalog> SubCatalogs { get; set; } = new List<Catalog>();
    public ICollection<CatalogItem> Items { get; set; } = new List<CatalogItem>();
}