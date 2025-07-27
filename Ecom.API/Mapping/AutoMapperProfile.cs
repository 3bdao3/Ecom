using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;

namespace Ecom.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Product mappings
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.NewPrice))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<AddProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            // Photo mappings
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();

            // Category mappings
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}