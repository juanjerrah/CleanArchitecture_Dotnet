using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using ProductDomain = CleanArchitecture.Domain.Entities.Product;

namespace CleanArchitecture.Infra.Data.Data.Product.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ApplicationDbContext _productContext;

    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }
    
    public async Task<IEnumerable<ProductDomain?>> GetProducts()
    {
        return await _productContext.Products.ToListAsync();
    }

    public async Task<ProductDomain?> GetProductById(Guid? id)
    {
        var product = _productContext.Products.FindAsync(id);
        return await product;
    }

    public async Task<ProductDomain?> GetProductByCategory(Guid? id)
    {
        return await _productContext.Products.Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ProductDomain?> CreateProduct(ProductDomain? product)
    {
        _productContext.Products.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<ProductDomain?> UpdateProduct(ProductDomain? product)
    {
        _productContext.Products.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<ProductDomain?> DeleteProduct(ProductDomain? product)
    {
        _productContext.Products.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}