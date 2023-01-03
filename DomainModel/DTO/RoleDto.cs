using DomainModel.Entity;

namespace DomainModel.DTO;

public class RoleDto : BaseDto
{
    public string Name { get; set; }

    public RoleDto(Role role)
    {
        Id = role.Id;
        Name = role.Name;
    }
}