using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainModel.Entity;

public class Category : BaseEntity
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }

    public virtual IList<Product> Products { get; set; } = new List<Product>();
    public virtual IList<Category> ChildCategories { get; set; } = new List<Category>();
    public virtual IList<Category> ParentCategories { get; set; } = new List<Category>();
}

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Id).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Name).NotNull().Length(2, 50);
        RuleFor(c => c.Products).NotNull();
        RuleFor(c => c.ChildCategories).NotNull();
        RuleFor(c => c.ParentCategories).NotNull();
    }
}