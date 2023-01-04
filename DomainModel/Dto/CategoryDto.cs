using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class CategoryDto : BaseDto
{
    public string Name { get; set; }

    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(c => c.Id).NotNull();
    }
}