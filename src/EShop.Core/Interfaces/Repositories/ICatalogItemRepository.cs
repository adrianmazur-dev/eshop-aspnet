using EShop.Core.Entities;

namespace EShop.Core.Interfaces.Repositories;

public interface ICatalogItemRepository
{
    Task<IReadOnlyList<CatalogItem>> GetAllAsync();
    Task<CatalogItem?> GetByIdAsync(int id);

    Task AddAsync(CatalogItem catalogItem);
    Task UpdateAsync(CatalogItem catalogItem);
    Task DeleteAsync(int id);
}