using EShop.Core.Entities;

namespace EShop.Core.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddItemToCartAsync(string userId, int catalogItemId, int quantity);
        Task RemoveItemFromCartAsync(string userId, int catalogItemId);
        Task ClearCartAsync(string userId);
    }
}
