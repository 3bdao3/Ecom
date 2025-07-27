using Ecom.Core.Entity.Product;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO
{
   public record ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual List<PhotoDto> Photos { get; set; }
        public string CategoryName { get; set; }
    }
    public record PhotoDto
    {
        public string ImageName { get; set; }

        public int ProductId { get; set; }
    }
    public record AddProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Product description is required")]
        [StringLength(500, ErrorMessage = "Product description cannot exceed 500 characters")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "New price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "New price must be greater than 0")]
        public decimal NewPrice { get; set; }
        
        [Required(ErrorMessage = "Old price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Old price must be greater than or equal to 0")]
        public decimal OldPrice { get; set; }
        
        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage = "At least one photo is required")]
        public IFormFileCollection Photo { get; set; }
    }
    public record UpdateProductDto:AddProductDto
    {
        [Required(ErrorMessage = "Product ID is required")]
        public int Id { get; set; }
    }

}
