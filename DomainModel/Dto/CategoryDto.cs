using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class CategoryDto : BaseDto
{
    public string Name { get; set; }
    public IList<int> ChildCategoryIds { get; set; } = new List<int>();
    public IList<int> ParentCategoryIds { get; set; } = new List<int>();

    public CategoryDto()
    {
    }

    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        ChildCategoryIds = category.ChildCategories.Select(x => x.Id).ToList();
        ParentCategoryIds = category.ParentCategories.Select(x => x.Id).ToList();
    }

    public override bool Equals(object obj)
    {
        var role = obj as CategoryDto;
        return role != null &&
               Id == role.Id &&
               Name == role.Name;
    }

    public override int GetHashCode()
    {
        var hashCode = -1509228638;
        hashCode = hashCode * -1521134295 + Id.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        return hashCode;
    }
}

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Id).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Name).NotNull().Length(2, 50);
        RuleFor(c => c.ChildCategoryIds).NotNull();
        RuleFor(c => c.ParentCategoryIds).NotNull();
    }
}