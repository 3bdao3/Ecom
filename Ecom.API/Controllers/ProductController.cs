using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;
using Ecom.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{

    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> get()
        {
            try
            {
                var Product = await work.ProductRepository
                    .GetAllAsync(x=>x.Category,x=>x.Photos);
                var result = mapper.Map<List<ProductDto>>(Product);

                if (Product is null)
                 { 
                    return BadRequest(new ResponsAPI(400));
                 }
                 return Ok(result);    

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var Product = await work.ProductRepository
                    .GetbyIdAsync(id, x => x.Category, x => x.Photos);
                var result = mapper.Map<ProductDto>(Product);
                if (Product is null)
                {
                    return BadRequest(new ResponsAPI(400));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-Product")]
        public async Task<IActionResult> AddProduct(AddProductDto addProductDto)
        {
            try
            {
                await work.ProductRepository.AddAsync(addProductDto);
                return Ok(new ResponsAPI(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(200, ex.Message));
            }
        }
        [HttpPut("update-Product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateproductDto)
        {
            try
            {
                await work.ProductRepository.UpdateAsync(updateproductDto);
                return Ok(new ResponsAPI(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponsAPI(200, ex.Message));
            }
        }
    }
}
