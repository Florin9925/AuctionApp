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

    public override bool Equals(object obj)
    {
        var role = obj as RoleDto;
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

public class RoleDtoValidator : AbstractValidator<RoleDto>
{
    public RoleDtoValidator()
    {
        RuleFor(r => r.Id).GreaterThanOrEqualTo(0);
        RuleFor(r => r.Name).MinimumLength(2);
        RuleFor(r => r.Name).NotNull();
    }
}