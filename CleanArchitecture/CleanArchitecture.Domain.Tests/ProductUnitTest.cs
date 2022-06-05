using CleanArchitecture.Domain.Entities;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Create Product with valid state")]
    public void CreateProduct_ValidState_Success()
    {
        Action action = () => new Product("ExName", "DescEx", 10.1m, 3, "ImageNameEx");
        action.Should()
            .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Product without name")]
    public void CreateProduct_MissingName_Exception()
    {
        Action action = () => new Product("", "DescEx", 10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is Required!");
    }
    
    [Fact(DisplayName = "Create Product with null name")]
    public void CreateProduct_NullName_Exception()
    {
        Action action = () => new Product(null, "DescEx", 10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is Required!");
    }
    
    [Fact(DisplayName = "Create Product with short name")]
    public void CreateProduct_ShortName_Exception()
    {
        Action action = () => new Product("Na", "DescEx", 10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name must be at least 3 letters!");
    }
    
    [Fact(DisplayName = "Create Product without description")]
    public void CreateProduct_MissingDesc_Exception()
    {
        Action action = () => new Product("Name", "", 10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Description: Description is Required!");
    }
    
    [Fact(DisplayName = "Create Product with null description")]
    public void CreateProduct_NullDesc_Exception()
    {
        Action action = () => new Product("Name", null, 10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Description: Description is Required!");
    }
    
    [Fact(DisplayName = "Create Product with short description")]
    public void CreateProduct_ShortDesc_Exception()
    {
        Action action = () => new Product("Name", "desc", 10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Description: Description must be at least 5 letters!");
    }
    
    [Fact(DisplayName = "Create Product with negative price")]
    public void CreateProduct_NegativePrice_Exception()
    {
        Action action = () => new Product("Name", "description", -10.1m, 3, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Price: Invalid price value");
    }
    
    [Theory(DisplayName = "Create Product with negative stock")]
    [InlineData(-5)]
    public void CreateProduct_NegativeStock_Exception(int value)
    {
        Action action = () => new Product("Name", "description", 10.1m, value, "ImageNameEx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Stock: Invalid stock quantity");
    }
    
    [Fact(DisplayName = "Create Product with image too long")]
    public void CreateProduct_LongImage_Exception()
    {
        Action action = () => new Product("Name", "description", 10.1m, 3, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Image name: Image must be up to 250 letters");
    }
    
    
}