using Microsoft.EntityFrameworkCore;
using CharitySystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".CharitySystem.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.IsEssential = true; 
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CharityDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:CharitySystemConnection"]);
});

builder.Services.AddScoped<ICharityRepository, EFCharityRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulated(app);

app.Run();
