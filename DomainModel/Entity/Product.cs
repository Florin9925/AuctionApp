using DomainModel.Enum;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public User Owner { get; set; }

        [Required]
        public Currency Currency { get; set; }


        public virtual IList<Auction> Offers { get; set; }

        public class Auction
        {
            public Product Product { get; }
            public int Id { get; set; }
            public decimal Price { get; set; }
            public Auction() { }

            public Auction(Product product)
            {
                Product = product;
            }
        }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.StartDate).LessThan(p => p.EndDate);
            RuleFor(p => p.StartDate).GreaterThan(DateTime.Now);
            RuleFor(p => p.Owner).NotNull();
            RuleFor(p => p.Currency).IsInEnum();
        }
    }
}
