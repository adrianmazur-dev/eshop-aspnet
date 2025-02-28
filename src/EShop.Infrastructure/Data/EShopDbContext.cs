﻿using EShop.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Data;

public class EShopDbContext(DbContextOptions<EShopDbContext> options) 
    : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>(options)
{
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EShopDbContext).Assembly);
    }
}