using EShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Data;

public class EShopDbContext(DbContextOptions<EShopDbContext> options) : DbContext(options)
{
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EShopDbContext).Assembly);
    }
}