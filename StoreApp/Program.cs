using StoreApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.ConfigureMapper();
builder.Services.ConfigureSession();

builder.Services.ConfigureDataBaseConnection(builder.Configuration);
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureCartStore();
builder.Services.ConfigureFileUpload();

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
