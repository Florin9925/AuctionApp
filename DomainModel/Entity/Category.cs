using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainModel.Entity;

public class Category : BaseEntity
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }

    public virtual IList<Product>? Products { get; set; }
    public virtual IList<Category>? ChildCategories { get; set; }
    public virtual IList<Category>? ParentCategories { get; set; }
}

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Id).NotNull();
    }
}