using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interface
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<bool> AddAsync(AddProductDto addProductDto);
        Task<bool> UpdateAsync(UpdateProductDto updateProductDto);

    }
}
