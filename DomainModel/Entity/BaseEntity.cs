using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace DomainModel.Entity;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}