using EShop.Core.Entities;
using EShop.Core.Interfaces.Repositories;
using EShop.Core.Interfaces.Services;

namespace EShop.Core.Services;

public class CatalogService(ICatalogRepository catalogRepository) : ICatalogService
{
    public async Task<IEnumerable<Catalog>> GetAllAsync()
    {
        return await catalogRepository.GetAllAsync();
    }

    public async Task<Catalog?> GetByIdAsync(int id)
    {
        return await catalogRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Catalog catalog)
    {
        await catalogRepository.AddAsync(catalog);
    }

    public async Task UpdateAsync(Catalog catalog)
    {
        await catalogRepository.UpdateAsync(catalog);
    }

    public async Task DeleteAsync(int id)
    {
        await catalogRepository.DeleteAsync(id);
    }
}