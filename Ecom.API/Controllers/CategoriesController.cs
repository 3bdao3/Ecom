using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;
using Ecom.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Ecom.API.Controllers
{
    
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult>get()
        {
            try
            {
                var category = await work.CategoryRepository.GetAllAsync();
                if(category == null)
                    return BadRequest(new ResponsAPI(400));
                
                return Ok(category);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-id")]
        public async Task<IActionResult> getbyId(int id)
        {
            try
            {
                var category = await work.CategoryRepository.GetbyIdAsync(id);
                if(category==null)
                    return BadRequest(new ResponsAPI(400,$"Not found Id{id}"));
                return Ok(category);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add-category")]
        public async Task<IActionResult> add(CategoryDto categoryDto)
        {
            try
            {
                var category =mapper.Map<Category>(categoryDto);    
                await work.CategoryRepository.AddAsync(category);
                return Ok(new ResponsAPI(200,"Item is ADD"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("update-categorty")]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var category = mapper.Map<Category>(updateCategoryDto);
                await work.CategoryRepository.UpdateAsync(category);
                return Ok(new ResponsAPI(200, "Item is Update"));



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delet-Category")]
        public async Task<IActionResult> delet(int id)
        {
            try
            {
                await work.CategoryRepository.DeletAsync(id);
                return Ok(new ResponsAPI(200, "Item is Delet"));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
    }
}
