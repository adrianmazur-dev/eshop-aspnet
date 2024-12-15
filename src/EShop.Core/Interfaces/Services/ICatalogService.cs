using EShop.Core.Entities;

namespace EShop.Core.Interfaces.Services;

public interface ICatalogService
{
    public Task<IEnumerable<Catalog>> GetAllAsync();
    public Task<Catalog?> GetByIdAsync(int id);

    public Task AddAsync(Catalog catalog);
    public Task UpdateAsync(Catalog catalog);
    public Task DeleteAsync(int id);
}