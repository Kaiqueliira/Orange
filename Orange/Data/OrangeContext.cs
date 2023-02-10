using Microsoft.EntityFrameworkCore;
using Orange.Mappings;
using Orange.Model;

namespace Orange.Data
{
    public class OrangeContext : DbContext
    {
        public OrangeContext(DbContextOptions<OrangeContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrailMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());

        }

        public DbSet<Trail> Trail { get; set; }
        public DbSet<Course> Course { get; set; }

    }
}
