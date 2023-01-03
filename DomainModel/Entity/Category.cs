using System.ComponentModel.DataAnnotations;

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