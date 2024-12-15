using EShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Data.Config;

public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired(true)
            .HasMaxLength(50);
        builder.Property(e => e.Description);

        builder.HasOne(e => e.ParentCatalog)
            .WithMany(e => e.SubCatalogs)
            .HasForeignKey(e => e.ParentCatalogId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Items)
            .WithOne(e => e.Catalog)
            .HasForeignKey(e => e.CatalogId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}