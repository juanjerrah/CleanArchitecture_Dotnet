using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using CategoryDomain = CleanArchitecture.Domain.Entities.Category;

namespace CleanArchitecture.Infra.Data.Data.Category.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationDbContext _categoryContext;
    
    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;
    }

    public async Task<IEnumerable<CategoryDomain>> GetCategories()
    {
        var categorias = _categoryContext.Categories.ToListAsync();
        return await categorias;
    }

    public async Task<CategoryDomain?> GetCategoryById(Guid? id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<CategoryDomain> CreateCategory(CategoryDomain category)
    {
        _categoryContext.Categories.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<CategoryDomain> UpdateCategory(CategoryDomain category)
    {
        _categoryContext.Categories.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<CategoryDomain> DeleteCategory(CategoryDomain category)
    {
        _categoryContext.Categories.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}