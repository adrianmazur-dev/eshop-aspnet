using EShop.Core.Entities;

namespace EShop.Core.Interfaces.Services;

public interface ICatalogItemService
{
    public Task<IEnumerable<CatalogItem>> GetAllAsync();
    public Task<CatalogItem?> GetByIdAsync(int id);

    public Task AddAsync(CatalogItem catalogItem);
    public Task UpdateAsync(CatalogItem catalogItem);
    public Task DeleteAsync(int id);
}