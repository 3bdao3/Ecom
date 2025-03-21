using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;

namespace Ecom.API.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();  

        }
    }
}
