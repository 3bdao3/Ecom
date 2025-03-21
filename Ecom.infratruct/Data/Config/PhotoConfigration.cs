using Ecom.Core.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infratruct.Data.Config
{
     public class PhotoConfigration:IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
           builder.HasData(
               new Photo { Id = 1, ImageName = "test", ProductId = 1 }
               );
        }
    }
}
