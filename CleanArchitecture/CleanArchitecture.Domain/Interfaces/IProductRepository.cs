using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product?>> GetProducts();
    Task<Product?> GetProductById(Guid? id);
    Task<Product?> GetProductByCategory(Guid? id);
    Task<Product?> CreateProduct(Product? product);
    Task<Product?> UpdateProduct(Product? product);
    Task<Product?> DeleteProduct(Product? product);
}