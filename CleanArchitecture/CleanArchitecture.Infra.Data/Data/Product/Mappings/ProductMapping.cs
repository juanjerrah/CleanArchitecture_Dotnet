using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductDomain = CleanArchitecture.Domain.Entities.Product;
namespace CleanArchitecture.Infra.Data.Data.Product.Mappings;

public class ProductMapping : IEntityTypeConfiguration<ProductDomain>
{
    public void Configure(EntityTypeBuilder<ProductDomain> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Price).HasPrecision(10, 2);
        builder.HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}