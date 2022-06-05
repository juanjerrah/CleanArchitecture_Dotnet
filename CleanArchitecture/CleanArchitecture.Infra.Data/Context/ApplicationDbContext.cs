using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infra.Data.Data.Category.Mappings;
using CleanArchitecture.Infra.Data.Data.Product.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    
    public DbSet<Product?> Products { get; set; }
    public DbSet<Category?> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //builder.ApplyConfiguration(new CategoryMapping());
        //builder.ApplyConfiguration(new ProductMapping());
    }
}