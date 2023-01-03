using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity;

public class Offer : BaseEntity
{
    [Required] public Product? Product { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] public User? Bidder { get; set; }

    [Required] public DateTime DateTime { get; set; }
}