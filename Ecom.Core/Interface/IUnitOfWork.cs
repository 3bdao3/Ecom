using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interface
{
   public interface IUnitOfWork
    {
        public IPhotoRepository PhotoRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }


    }
}
