using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Entity.Product
{
  public  class Product:BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Precision(18, 2)]

        public decimal NewPrice { get; set; }
        [Precision(18, 2)]

        public decimal OldPrice { get; set; }

        public virtual List<Photo> Photos { get;set ; } = new List<Photo>();
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;
    }
}
