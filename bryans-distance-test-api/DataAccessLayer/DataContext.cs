using bryans_distance_test_api.DataAccessLayer.DatabaseClasses;
using Microsoft.EntityFrameworkCore;

namespace bryans_distance_test_api.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Travel>().ToTable("Travel")
                .HasMany(c => c.Coordinates)
                .WithOne(o=>o.Travel)
                .IsRequired();

            modelBuilder.Entity<Coordinates>().ToTable("Coordinates");
        }
    }
}
