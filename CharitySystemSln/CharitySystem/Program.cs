using Microsoft.EntityFrameworkCore;
using CharitySystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CharityDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:CharitySystemConnection"]);
});
builder.Services.AddScoped<ICharityRepository, EFCharityRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
