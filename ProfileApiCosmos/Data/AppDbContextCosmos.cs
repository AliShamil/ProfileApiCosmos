using Microsoft.EntityFrameworkCore;
using ProfileApiCosmos.Models;

namespace ProfileApiCosmos.Data
{
    public class AppDbContextCosmos : DbContext
    {
        public AppDbContextCosmos(DbContextOptions options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToContainer("Users");

        }

        public DbSet<User>? Users { get; set; }
    }
}
