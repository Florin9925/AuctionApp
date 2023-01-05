using DomainModel.Entity;
using DomainModel.Enum;
using FluentValidation;

namespace DomainModel.Dto;

public class ProductDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int OwnerId { get; set; }
    public Currency Currency { get; set; }
    public int CategoryId { get; set; }
    public int Amount { get; set; }

    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        StartDate = product.StartDate;
        EndDate = product.EndDate;
        OwnerId = product.Owner.Id;
        Currency = product.Currency;
        Amount = product.Amount;
        CategoryId = product.Category.Id;
    }

    public ProductDto()
    {
    }
}

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Id).GreaterThanOrEqualTo(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.Description).MinimumLength(2);
        RuleFor(p => p.StartDate).LessThan(p => p.EndDate).WithMessage("Start date must be before end date");
        RuleFor(p => p.StartDate).GreaterThan(DateTime.Now).WithMessage("Start date must be in the future");
        RuleFor(p=>p.OwnerId).GreaterThan(0);
        RuleFor(p => p.Currency).IsInEnum();
        RuleFor(p => p.Amount).GreaterThan(0);
        RuleFor(p => p.CategoryId).GreaterThan(0);
    }
}