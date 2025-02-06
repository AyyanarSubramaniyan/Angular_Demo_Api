using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Reflection;

namespace DataLibraryProject
{
    public class SampleProjectDbContext : DbContext
    {
        public DbSet<State> StatesDetails { get; set; }
        public DbSet<Country> CountryDetails { get; set; }
        public SampleProjectDbContext(DbContextOptions<SampleProjectDbContext> options)
           : base(options)
        {

        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
