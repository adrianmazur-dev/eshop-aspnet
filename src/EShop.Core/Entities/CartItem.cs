using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Core.Entities;

public class CartItem : BaseEntity
{
    public int Quantity { get; set; }
    public int CartId { get; set; }
    public int CatalogItemId { get; set; }

    [ForeignKey(nameof(CatalogItemId))]
    public CatalogItem CatalogItem { get; set; } = null!;

    [ForeignKey(nameof(CartId))]
    public Cart Cart { get; set; } = null!;
}