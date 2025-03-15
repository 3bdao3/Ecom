﻿using Ecom.Core.Interface;
using Ecom.infratruct.Data;
using Ecom.infratruct.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infratruct
{
  
        public static class infrastructionRegesteration
        {
            public static IServiceCollection infrastructionConfigration(this IServiceCollection services, IConfiguration configuration)
            {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IPhotoRepository , PhotoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

                services.AddDbContext<AppDbContext>(op =>
                {
                    op.UseSqlServer(configuration.GetConnectionString("ECOM"));
                });

                return services;
            }
        }


    
}
