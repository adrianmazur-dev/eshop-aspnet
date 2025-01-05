using EShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Data.Config;

public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .IsRequired(false);

        builder.Property(e => e.Price)
            .IsRequired(true)
            .HasDefaultValue(0)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Catalog)
            .WithMany(e => e.Items)
            .HasForeignKey(e => e.CatalogId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
    }
}