using EShop.Core.Entities;
using EShop.Core.Interfaces.Repositories;
using EShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Repositories;

public class CatalogItemRepository(EShopDbContext context) :
    EfRepository(context), 
    ICatalogItemRepository
{
    public async Task<IReadOnlyList<CatalogItem>> GetAllAsync()
    {
        return await _context.CatalogItems
            .ToListAsync();
    }

    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        return await _context.CatalogItems
            .FindAsync(id);
    }

    public async Task AddAsync(CatalogItem catalogItem)
    {
        ArgumentNullException.ThrowIfNull(catalogItem);

        await _context.CatalogItems.AddAsync(catalogItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CatalogItem catalogItem)
    {
        ArgumentNullException.ThrowIfNull(catalogItem);

        _context.CatalogItems.Update(catalogItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var catalogItem = await GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(catalogItem);

        _context.CatalogItems.Remove(catalogItem);
        await _context.SaveChangesAsync();
    }
}