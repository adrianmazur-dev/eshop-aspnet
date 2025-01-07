using EShop.Core.Entities;
using EShop.Core.Interfaces.Repositories;
using EShop.Core.Interfaces.Services;

namespace EShop.Core.Services
{
    public class CartService(ICartRepository cartRepository) : ICartService
    {
        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await cartRepository.GetCartByUserIdAsync(userId);
        }

        public async Task AddItemToCartAsync(string userId, int catalogItemId, int quantity)
        {
            await cartRepository.AddItemToCartAsync(userId, catalogItemId, quantity);
        }

        public async Task RemoveItemFromCartAsync(string userId, int catalogItemId)
        {
            await cartRepository.RemoveItemFromCartAsync(userId, catalogItemId);
        }

        public async Task ClearCartAsync(string userId)
        {
            await cartRepository.ClearCartAsync(userId);
        }
    }
}
