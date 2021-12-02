using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

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
            // base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Country>().HasMany(p => p.States).WithOne();

            // modelBuilder.HasDefaultSchema("Admin"); 

            //var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            //foreach (var property in keysProperties)
            //{
            //    property.ValueGenerated = ValueGenerated.OnAdd;
            //}

            ////Map entity to table
            //modelBuilder.Entity<State>().ToTable("StateInfo");
            //modelBuilder.Entity<Country>().ToTable("CountryInfo", "dbo");

            // modelBuilder.Entity<State>()
            //.Property(s => s.Id)
            //.HasColumnName("Id")
            //.HasDefaultValue(0)
            //.IsRequired();           

            // modelBuilder.Entity<Country>()
            //  .Property(s => s.Id)
            //  .HasColumnName("Id")
            //  .HasDefaultValue(0)
            //  .IsRequired();
             
        }
    }
}
