using Ecom.Core.Entity.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO
{
   public record ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public virtual List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        public string CategoryName { get; set; } = string.Empty;
    }
    public record PhotoDto
    {
        public string ImageName { get; set; } = string.Empty;

        public int ProductId { get; set; }
    }
    public record AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public IFormFileCollection? Photo { get; set; }
    }
    public record UpdateProductDto:AddProductDto
    {
        public int Id { get; set; }
    }

}
