using EShop.Core.Entities;
using EShop.Core.Interfaces.Repositories;
using EShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Repositories
{
    public class CartRepository(EShopDbContext context) : 
        EfRepository(context),
        ICartRepository
    {
        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.CatalogItem)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>()
                };
                _context.Carts.Add(cart);
            }

            return cart;
        }

        public async Task AddItemToCartAsync(string userId, int catalogItemId, int quantity)
        {
            var cart = await GetCartByUserIdAsync(userId);

            var cartItem = cart.Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CatalogItemId = catalogItemId,
                    Quantity = quantity,
                    CartId = cart.Id,
                    Cart = cart
                };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(string userId, int catalogItemId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            var cartItem = cart.Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await GetCartByUserIdAsync(userId);

            cart.Items.Clear();
            await _context.SaveChangesAsync();
        }
    }
}
