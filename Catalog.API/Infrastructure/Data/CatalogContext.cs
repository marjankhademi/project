using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Data
{
    public class CatalogContext : DbContext
    {
        //SQL Server(IP, User, Password, Database Name, ...)
        public CatalogContext(DbContextOptions<CatalogContext> options)//DI
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            //Other Config

            //Ralationships
            //product -> image 
            modelBuilder.Entity<Product>()
                      // .HasMany<Image>()
                     .HasMany(p => p.Images)
                       .WithOne()
                       // .WithOne(i=>i.Owner)
                      .IsRequired()
                     // .HasForeignKey(i => i.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
          
            //.HasMany<Image>()
            //.HasPrincipalKey(p=>p.PartNumber)
            //.HasForeignKey(p=>p.ProductPartNumber);

            //modelBuilder.Entity<Image>()
            //            .HasOne<Product>()
            //            .WithMany();

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}