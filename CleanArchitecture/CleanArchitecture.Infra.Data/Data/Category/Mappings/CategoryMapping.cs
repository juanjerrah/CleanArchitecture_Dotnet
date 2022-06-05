using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CategoryDomain = CleanArchitecture.Domain.Entities.Category;
namespace CleanArchitecture.Infra.Data.Data.Category.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<CategoryDomain>
{
    public void Configure(EntityTypeBuilder<CategoryDomain> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        
    }
}