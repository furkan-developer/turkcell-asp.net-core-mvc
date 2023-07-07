using Microsoft.EntityFrameworkCore;
using Repository.EfCore;
using Repository.Contracts;
using Repository.Concrete;
using Repository;
using Services.Contracts;
using Services.Concrete;
using Services;
using System.Reflection;
using StoreApp.Utilities.FileUpload;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("sqlite3"),b => b.MigrationsAssembly("StoreApp")));

// Repository Layer refereces
builder.Services.AddScoped(typeof(IProductRepository),typeof(ProductRepository));
builder.Services.AddScoped(typeof(ICategoryRepository),typeof(CategoryRepository));
builder.Services.AddScoped(typeof(IRepositoryManager),typeof(RepositoryManager));

// Service Layer refereces
builder.Services.AddScoped(typeof(IProductService),typeof(ProductManager));
builder.Services.AddScoped(typeof(ICategoryService),typeof(CategoryManager));
builder.Services.AddScoped(typeof(IServiceManager),typeof(ServiceManager));

//Utility references
builder.Services.AddTransient<IBufferedFileUpload,BufferedFileUpload>();

var app = builder.Build();

// Redirecting HTTP Requests to HTTPs.
app.UseHttpsRedirection();

// Use static files under wwwroot folder
app.UseStaticFiles();

// Resolving Requests and creates endpoint.
app.UseRouting();

// Mapping endpoints with a controller action
app.UseEndpoints(endpoints => {
    
    endpoints.MapAreaControllerRoute(
        name:"admin",
        areaName:"admin",
        pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Product}/{action=Index}/{id?}"
    );
});

app.Run();
