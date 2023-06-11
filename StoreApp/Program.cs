using Microsoft.EntityFrameworkCore;
using Repository.EfCore;
using Repository.Contracts;
using Repository.Concrete;
using Repository;
using Services.Contracts;
using Services.Concrete;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("sqlite3"),b => b.MigrationsAssembly("StoreApp")));

builder.Services.AddScoped(typeof(IProductRepository),typeof(ProductRepository));
builder.Services.AddScoped(typeof(ICategoryRepository),typeof(CategoryRepository));
builder.Services.AddScoped(typeof(IRepositoryManager),typeof(RepositoryManager));

builder.Services.AddScoped(typeof(IProductService),typeof(ProductManager));
builder.Services.AddScoped(typeof(IServiceManager),typeof(ServiceManager));

var app = builder.Build();

// Redirecting HTTP Requests to HTTPs.
app.UseHttpsRedirection();

// Use static files under wwwroot folder
app.UseStaticFiles();

// Resolving Requests and creates endpoint.
app.UseRouting();

// Mapping endpoint with controller action.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
