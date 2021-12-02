using Entity;
using Entity.Country;
using Entity.State;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DataLibraryProject
{
    public class DataBaseContext : DbContext
    { 
        public DbSet<StateDetail> StatesDetails { get; set; }
        public DbSet<CountryDetail> CountryDetails { get; set; }       
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
           : base(options)
        {

        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasDefaultSchema("public");

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<StateDetail>()
            //  .Property(s => s.Id)
            //  .HasColumnName("Id")
            //  .HasDefaultValue(0)
            //  .IsRequired();

            //modelBuilder.Entity<CountryDetail>()
            // .Property(s => s.Id)
            // .HasColumnName("Id")
            // .HasDefaultValue(0)
            // .IsRequired();

        }
    }
}
