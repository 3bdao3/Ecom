using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entity.Product;
using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.infratruct.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infratruct.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;
        private readonly IImageManagementService imageManagementService;
        public ProductRepository(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.mapper = mapper;
            this.context = context;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDto addProductDto)
        {
            if (addProductDto is null) return false;
            var product = mapper.Map<Product>(addProductDto);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var Imagepath = await imageManagementService.AddImageAsync(addProductDto.Photo, addProductDto.Name);

            var photo = Imagepath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id
            }


                ).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

       

        public async Task<bool> UpdateAsync(UpdateProductDto updateProductDto)
        {
            if(updateProductDto is null) return (false);
            var Findproduct = await context.Products.Include(m => m.Category)
                .Include(e => e.Photos)
                .FirstOrDefaultAsync(x => x.Id == updateProductDto.Id);
            if(Findproduct == null) return (false);
            
            mapper.Map(updateProductDto, Findproduct);
            var Findphoto=await context.Photos.Where(c=>c.ProductId == updateProductDto.Id).ToListAsync();
            foreach (var item in Findphoto)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            context.Photos.RemoveRange(Findphoto);
            var imagepath = await imageManagementService.AddImageAsync(updateProductDto.Photo, updateProductDto.Name);
            var photo = imagepath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = updateProductDto.Id
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task DeletAsync(Product product)
        {
            var findphoto= await context.Photos.Where(c => c.ProductId == product.Id).ToListAsync();
            foreach (var item in findphoto)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            //context.Photos.RemoveRange(findphoto);
            context.Products.Remove(product);
           await context.SaveChangesAsync();
        }
    }
}
