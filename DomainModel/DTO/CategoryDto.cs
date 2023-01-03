using DomainModel.Entity;

namespace DomainModel.DTO;

public class CategoryDto : BaseDto
{
    public string Name { get; set; }

    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}