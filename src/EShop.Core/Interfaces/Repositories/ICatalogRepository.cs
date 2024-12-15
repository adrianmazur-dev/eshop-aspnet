using EShop.Core.Entities;

namespace EShop.Core.Interfaces.Repositories;

public interface ICatalogRepository
{
    Task<IReadOnlyList<Catalog>> GetAllAsync();
    Task<Catalog?> GetByIdAsync(int id);

    Task AddAsync(Catalog catalog);
    Task UpdateAsync(Catalog catalog);
    Task DeleteAsync(int id);
}