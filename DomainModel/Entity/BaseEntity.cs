using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}