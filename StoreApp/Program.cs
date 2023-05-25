var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Redirecting HTTP Requests to HTTPs.
app.UseHttpsRedirection();

// Resolving Requests and creates endpoint.
app.UseRouting();

// Mapping endpoint with controller action.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
