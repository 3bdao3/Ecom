using Ecom.Core.Interface;
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
        public IPhotoRepository PhotoRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            PhotoRepository = new PhotoRepository(_context);
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }
    }
}
