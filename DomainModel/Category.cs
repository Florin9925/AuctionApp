using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<Category>? ChildCategories { get; set; }
        public virtual ICollection<Category>? ParentCategories { get; set; }
    }
}
