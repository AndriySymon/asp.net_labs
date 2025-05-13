using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CharitySystem.Models
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(
        DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistrationModel> EventRegistrations { get; set; }
    }
}
