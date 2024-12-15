using EShop.Core.Entities;
using EShop.Core.Interfaces.Repositories;
using EShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Repositories;

public class CatalogRepository(EShopDbContext context) : 
    EfRepository(context), 
    ICatalogRepository
{
    public async Task<IReadOnlyList<Catalog>> GetAllAsync()
    {
        return await _context.Catalogs
            .ToListAsync();
    }

    public async Task<Catalog?> GetByIdAsync(int id)
    {
        return await _context.Catalogs
            .FindAsync(id);
    }

    public async Task AddAsync(Catalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);

        await _context.Catalogs.AddAsync(catalog);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Catalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);

        _context.Catalogs.Update(catalog);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var catalog = await GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(catalog);

        _context.Catalogs.Remove(catalog);
        await _context.SaveChangesAsync();
    }
}