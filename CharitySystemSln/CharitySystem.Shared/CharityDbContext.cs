using Microsoft.EntityFrameworkCore;

namespace CharitySystem.Models
{
    public class CharityDbContext : DbContext
    {
        public CharityDbContext(DbContextOptions<CharityDbContext> options) : base(options) { }
        public DbSet<Event> Events => Set<Event>();
        public DbSet<EventRegistrationModel> EventRegistrations { get; set; }
        public DbSet<UserModel> Users { get; set; }

    }
}
