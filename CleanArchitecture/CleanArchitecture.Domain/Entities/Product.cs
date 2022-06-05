using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string? image)
    {
        ValidateProductDomain(name, description, price, stock, image);
    }

    public Product(Guid id, string name, string description, decimal price, int stock, string? image)
    {
        DomainExceptionValidation.When(id.GetType() != typeof(Guid),"Invalid Id");
        Id = id;
        ValidateProductDomain(name, description, price, stock, image);
    }

    public void UpdateProduct(string name, string description, decimal price, int stock, string? image, Guid categoryId)
    {
        ValidateProductDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateProductDomain(string name, string description, decimal price, int stock, string? image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid Name: Name is Required!");
        DomainExceptionValidation.When(name.Length <= 3,
            "Invalid Name: Name must be at least 3 letters!");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "Invalid Description: Description is Required!");
        DomainExceptionValidation.When(description.Length <= 5,
            "Invalid Description: Description must be at least 5 letters!");
        DomainExceptionValidation.When(price < 0.0m, 
            "Invalid Price: Invalid price value");
        DomainExceptionValidation.When(stock < 0, 
            "Invalid Stock: Invalid stock quantity");
        DomainExceptionValidation.When(image?.Length > 250,
            "Invalid Image name: Image must be up to 250 letters");
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}