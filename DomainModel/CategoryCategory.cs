using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class CategoryCategory
    {
        [Key, Column(Order = 0)]
        public int ParentID { get; set; }

        [Key, Column(Order = 1)]
        public int ChildID { get; set; }

        public virtual Category? Child { get; set; }
        public virtual Category? Parent { get; set; }
    }
}
