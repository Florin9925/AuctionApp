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

    public RoleDto()
    {
    }
}

public class RoleDtoValidator : AbstractValidator<RoleDto>
{
    public RoleDtoValidator()
    {
        RuleFor(r => r.Id).GreaterThanOrEqualTo(0);
        RuleFor(r => r.Name).MinimumLength(2);
        RuleFor(r => r.Name).NotNull();
    }
}