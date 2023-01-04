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
    }
}

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Id).NotNull();
    }
}