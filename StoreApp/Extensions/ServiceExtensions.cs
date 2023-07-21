using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Concrete;
using Repository.Contracts;
using Repository.EfCore;
using Services;
using Services.Concrete;
using Services.Contracts;
using StoreApp.Models.Carts;
using StoreApp.Utilities.FileUpload;

namespace StoreApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataBaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
        options => options.UseSqlite(configuration.GetConnectionString("sqlite3"), b => b.MigrationsAssembly("StoreApp")));
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IRepositoryManager), typeof(RepositoryManager));
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductService), typeof(ProductManager));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryManager));
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        public static void ConfigureCartStore(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(serviceProvider => SessionCart.GetCart(serviceProvider));
        }

        public static void ConfigureFileUpload(this IServiceCollection services)
        {
            services.AddTransient<IBufferedFileUpload, BufferedFileUpload>();
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}