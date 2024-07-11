using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure
{
    public class JourneyDBContext : DbContext
    {
        public DbSet<Trip> Trips { get; set;}

        public DbSet<Activity> Activities { get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\USER\\Desktop\\Elisangela\\AProjetos\\Journey\\src\\Journey.Infrastructure\\JourneyDatabase.db");
        }

    }
}