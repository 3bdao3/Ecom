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
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public virtual List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        public required string CategoryName { get; set; }
    }
    public record PhotoDto
    {
        public required string ImageName { get; set; }

        public int ProductId { get; set; }
    }
    public record AddProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public required IFormFileCollection Photo { get; set; }
    }
    public record UpdateProductDto:AddProductDto
    {
        public int Id { get; set; }
    }

}
