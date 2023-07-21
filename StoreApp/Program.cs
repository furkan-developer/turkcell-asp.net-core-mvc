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
using StoreApp.Models.Carts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

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

// Cart and session service register
builder.Services.AddScoped(typeof(Cart), serviceProvider => SessionCart.GetCart(serviceProvider));
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Utility references
builder.Services.AddTransient<IBufferedFileUpload,BufferedFileUpload>();

var app = builder.Build();

// Redirecting HTTP Requests to HTTPs.
app.UseHttpsRedirection();

// Use static files under wwwroot folder
app.UseStaticFiles();

// Resolving Requests and creates endpoint.
app.UseRouting();

app.UseSession();

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

    endpoints.MapRazorPages();
});

app.Run();
