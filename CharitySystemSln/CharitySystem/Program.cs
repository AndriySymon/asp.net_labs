using Microsoft.EntityFrameworkCore;
using CharitySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

builder.Services.AddDbContext<CharityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CharitySystemConnection")));

builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
    builder.Configuration["ConnectionStrings:IdentityConnection"])
);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulated(app);

app.MapHub<CharitySystem.Hubs.EventHub>("/eventHub");

app.Run();
