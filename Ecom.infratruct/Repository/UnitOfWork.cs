using AutoMapper;
using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.infratruct.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infratruct.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;
        public IPhotoRepository PhotoRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService)
        {
            this.mapper = mapper;

            _context = context;
            this.imageManagementService = imageManagementService;
            PhotoRepository = new PhotoRepository(_context);
            ProductRepository = new ProductRepository(_context,mapper, imageManagementService);
            CategoryRepository = new CategoryRepository(_context);
        }
    }
}
