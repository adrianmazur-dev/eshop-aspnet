namespace EShop.Infrastructure.Data;

public class EfRepository(EShopDbContext context)
{
    protected readonly EShopDbContext _context = context;
}