using System.ComponentModel.DataAnnotations.Schema;
using EShop.Core.Interfaces;

namespace EShop.Core.Entities;

public class CatalogItem : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null;
    public decimal Price { get; set; } = 0;
    public int CatalogId { get; set; }

    [ForeignKey(nameof(CatalogId))]
    public Catalog Catalog { get; set; } = null!;
}