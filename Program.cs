using GameSphere.Models;
using Microsoft.EntityFrameworkCore;
using Vite.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add the Vite services.
builder.Services.AddViteServices(options =>
{
    options.PackageDirectory = "Frontend";
    options.Server.AutoRun = true;
    options.Server.Https = true;
    options.Server.UseFullDevUrl = true;
    options.Manifest = ".vite/manifest.json";
});

builder.Services.AddDbContext<GameSphereContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameSphereContext")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Create db if it doesn't exist
using (IServiceScope scope = app.Services.CreateScope())
{
    GameSphereContext context = scope.ServiceProvider.GetRequiredService<GameSphereContext>();
    context.Database.EnsureCreated();
    context.Initialize();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    // Use Vite Dev Server as middleware.
    app.UseViteDevMiddleware();
}

app.Run();
