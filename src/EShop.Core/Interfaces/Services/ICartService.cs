using EShop.Core.Entities;

namespace EShop.Core.Interfaces.Services
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddItemToCartAsync(string userId, int catalogItemId, int quantity);
        Task RemoveItemFromCartAsync(string userId, int catalogItemId);
        Task ClearCartAsync(string userId);
    }
}
