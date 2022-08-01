using IdentityProjectPractise.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Gender> Genders{ get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Colors> colors { get; set; }
        public DbSet<CartSystem> cartSystem { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Rate> ratings { get; set; }


        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer("Data Source=DESKTOP-QPSQJ2O; Trust Server Certificate=true; integrated security=true; database=ZayShopDb ");
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-EI33INB\\UMERSQLSERVER; user id=admin; password=123; Initial Catalog=ZayShopDb");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
