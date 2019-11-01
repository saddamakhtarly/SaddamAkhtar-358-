using EVS358.PropertyHub;
using EVS358.UsersMgt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVS358
{
    public class PropertyHubContext : DbContext 
    {
        public PropertyHubContext()  
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //this connection string should be read from configuration file           
            optionsBuilder.UseSqlServer("data source=.;Initial Catalog = EVS358-update; Integrated Security = True; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasOne<Province>(p => p.Province)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Province>()
                .HasOne<Country>(p => p.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Role>(u => u.Role)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Address>(u => u.Address)
                .WithOne()
                .HasForeignKey<Address>(u=>u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Neighborhood>()
                .HasOne<Neighborhood>(n => n.Parent)
                .WithMany();
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Neighborhood>()
              .HasOne<City>(n => n.City)
              .WithMany()
              .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PropertyArea>()
                .HasOne<AreaUnit>(pa => pa.Unit)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
                .HasOne<PropertyArea>(adv => adv.Area)
                .WithOne()
                .IsRequired()
                .HasForeignKey<PropertyArea>(pa=>pa.PropertyAdvId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<PropertyType>(adv => adv.PropertyType)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<PropertyType>(adv => adv.PropertyType)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<AdvType>(adv => adv.AdvType)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<AdvStatus>(adv => adv.AdvStatus)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<Neighborhood>(adv => adv.Neighborhood)
               .WithMany();
              // .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<User>(adv => adv.PostedBy)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasMany<PropertyImage>(adv => adv.Images)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdvsFeatures>()
                .HasOne<PropertyAdv>(paf => paf.Advertisement)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdvsFeatures>()
                .HasOne<PropertyFeature>(paf => paf.Feature)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<PropertyAdvPropertyFeature>()
            //    .HasOne<PropertyAdv>(x=>x.Advertisement)
            //    .WithMany();

            //modelBuilder.Entity<PropertyAdvPropertyFeature>()
            //    .HasOne<PropertyFeature>(x=>x.Feature)
            //    .WithMany();




        }

      


        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User>  Users { get; set; }

        public DbSet<AdvType> AdvTypes { get; set; }
        public DbSet<AdvStatus> AdvStatus { get; set; }

        public DbSet<AreaUnit> AreaUnits { get; set; }

        public DbSet<Neighborhood> Neighborhoods { get; set; }

        public DbSet<PropertyAdv> PropertyAdvs { get; set; }
        public virtual DbSet<PropertyImage> PropertyImage { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyAdvsFeatures> PropertyAdvsFeatures { get; set; }


        public DbSet<PropertyFeature> PropertyFeatures { get; set; }









    }
}
