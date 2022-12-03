using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Post 1",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Description for post 1",
                        Category = "Category 1",
                        City = "Mc Lean",
                        Venue = "8000 West Park Dr"
                    },
                    new Activity
                    {
                        Title = "Post 2",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Description for post 2",
                        Category = "Category 2",
                        City = "Woodbridge",
                        Venue = "1304 Bayside Ave"
                    },
                    new Activity
                    {
                        Title = "Post 3",
                        Date = DateTime.Now.AddMonths(-3),
                        Description = "Description for post 3",
                        Category = "Category 3",
                        City = "Washington DC",
                        Venue = "my address"
                    }
                };
                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
        }
        }
    }
}