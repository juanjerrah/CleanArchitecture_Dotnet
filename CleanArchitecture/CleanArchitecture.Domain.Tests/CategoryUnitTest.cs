using CleanArchitecture.Domain.Entities;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Create Category with valid state")]
    public void CreateCategory_WithValidParameters_Success()
    {
        Action action = () => new Category(Guid.NewGuid(), "Category Name");
        action.Should()
            .NotThrow<CleanArchitecture.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category with short name")]
    public void CreateCategory_ShortName_DomainException()
    {
        Action action = () => new Category(Guid.NewGuid(), "Ca");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name must be at least 3 letters!");
    }
    
    [Fact(DisplayName = "Create Category without name")]
    public void CreateCategory_MissingName_DomainException()
    {
        Action action = () => new Category(Guid.NewGuid(), "");
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is Required");
    }
    
    [Fact(DisplayName = "Create Category with null name")]
    public void CreateCategory_NullName_DomainException()
    {
        Action action = () => new Category(Guid.NewGuid(), null);
        action.Should()
            .Throw<CleanArchitecture.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Name: Name is Required");
    }
    
}