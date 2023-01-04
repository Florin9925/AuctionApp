using DomainModel.Entity;
using FluentValidation;

namespace DomainModel.Dto;

public class RoleDto : BaseDto
{
    public string Name { get; set; }

    public RoleDto(Role role)
    {
        Id = role.Id;
        Name = role.Name;
    }
}

public class RoleDtoValidator : AbstractValidator<RoleDto>
{
    public RoleDtoValidator()
    {
        RuleFor(r => r.Id).NotNull();
    }
}