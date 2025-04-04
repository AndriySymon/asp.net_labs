using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CharitySystem.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CharityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<CharityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                new Event
                {
                    Id = 1,
                    Title = "Charity Marathon",
                    Description = "A marathon to raise funds for local hospitals.",
                    Date = new DateTime(2025, 5, 20),
                    Location = "Central Park, NY",
                    Capacity = 500,
                    FundraisingGoal = 10000m,
                    Category = "Sports"
                },
                new Event
                {
                    Id = 2,
                    Title = "Food Drive",
                    Description = "Collecting food for families in need.",
                    Date = new DateTime(2025, 6, 10),
                    Location = "Community Center, LA",
                    Capacity = 200,
                    FundraisingGoal = 5000m,
                    Category = "Sports"
                },
                new Event
                {
                    Id = 3,
                    Title = "Beach Cleanup",
                    Description = "Join us to clean the coastline and protect marine life.",
                    Date = new DateTime(2025, 4, 15),
                    Location = "Santa Monica Beach, CA",
                    Capacity = 150,
                    FundraisingGoal = 2000m,
                    Category = "Environment"
                }
                );
                context.SaveChanges();
            }
        }
    }
}
