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
    public decimal InitialPrice { get; set; }
    public bool IsCompleted { get; set; } = false;

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
        InitialPrice = product.InitialPrice;
        IsCompleted = product.IsCompleted;
    }

    public ProductDto()
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is ProductDto dto &&
               Id == dto.Id &&
               Name == dto.Name &&
               Description == dto.Description &&
               StartDate == dto.StartDate &&
               EndDate == dto.EndDate &&
               OwnerId == dto.OwnerId &&
               Currency == dto.Currency &&
               CategoryId == dto.CategoryId &&
               Amount == dto.Amount &&
               InitialPrice == dto.InitialPrice &&
               IsCompleted == dto.IsCompleted;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            Id,
            Name,
            Description,
            OwnerId,
            CategoryId,
            Amount,
            InitialPrice,
            IsCompleted);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Description: {Description}, StartDate: {StartDate}, EndDate: {EndDate}, OwnerId: {OwnerId}, Currency: {Currency}, CategoryId: {CategoryId}, Amount: {Amount}, InitialPrice: {InitialPrice}, IsCompleted: {IsCompleted}";
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
        RuleFor(p => p.OwnerId).GreaterThan(0);
        RuleFor(p => p.Currency).IsInEnum();
        RuleFor(p => p.Amount).GreaterThan(0);
        RuleFor(p => p.CategoryId).GreaterThan(0);
        RuleFor(p => p.InitialPrice).GreaterThanOrEqualTo(0);
    }
}