using EShop.Core.Entities;
using EShop.Core.Interfaces.Repositories;
using EShop.Core.Interfaces.Services;

namespace EShop.Core.Services;

public class CatalogItemService(ICatalogItemRepository catalogItemRepository) : ICatalogItemService
{
    public async Task<IEnumerable<CatalogItem>> GetAllAsync()
    {
        return await catalogItemRepository.GetAllAsync();
    }

    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        return await catalogItemRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(CatalogItem catalogItem)
    {
        await catalogItemRepository.AddAsync(catalogItem);
    }

    public async Task UpdateAsync(CatalogItem catalogItem)
    {
        await catalogItemRepository.UpdateAsync(catalogItem);
    }

    public async Task DeleteAsync(int id)
    {
        await catalogItemRepository.DeleteAsync(id);
    }
}