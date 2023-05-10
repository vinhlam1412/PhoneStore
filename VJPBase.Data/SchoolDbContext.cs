using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJPBase.Data.Entities;

namespace VJPBase.Data
{
    public class SchoolDbContext : DbContext
    {
   
        public SchoolDbContext()
        {
        }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
               : base(options)
        {
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(e =>
            {
                e.ToTable("Brand");
                e.HasKey(b => b.Id);
                e.Property(b => b.Name).IsRequired();
                e.Property(n => n.IsDeleted).HasDefaultValue(false);
            });
            modelBuilder.Entity<Customer>(e =>
            {
                e.ToTable("Customer");
                e.HasKey(b => b.Id);
                e.Property(n => n.Name).IsRequired().HasMaxLength(250);
                e.Property(n => n.Phone).IsRequired().HasMaxLength(10);
                e.Property(n => n.Address).IsRequired().HasMaxLength(250);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(b => b.Id);
                e.HasOne(e => e.Customer)
                .WithMany(e => e.orders)
                .HasForeignKey(e => e.Id_Customer);
            });

            modelBuilder.Entity<Order_Detail>(e =>
            {
                e.ToTable("Order_Detail");
                e.HasKey(e => new { e.Id_Order, e.Id_Product });

                e.HasOne(e => e.Order)
                .WithMany(e => e.order_Details)
                .HasForeignKey(e => e.Id_Order);

                e.HasOne(e => e.Product)
                .WithMany(e => e.order_Details)
                .HasForeignKey(e => e.Id_Product);

            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.Property(n => n.Name).IsRequired().HasMaxLength(250);
                e.Property(n => n.Price).IsRequired();
                e.Property(n => n.Description).IsRequired();
                e.Property(n => n.IsDeleted).HasDefaultValue(false);
                e.HasKey(b => b.Id);
                e.HasOne(e => e.Brand)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.Id_Brand);
            });

            modelBuilder.Entity<Store>(e =>
            {
                e.ToTable("Store");
                e.HasKey(e => e.Id);
                e.Property(n => n.Name).IsRequired().HasMaxLength(250);
                e.Property(n => n.Phone).IsRequired().HasMaxLength(10);
                e.Property(n => n.Address).IsRequired().HasMaxLength(250);
            });

            modelBuilder.Entity<Store_Detail>(e =>
            {
                e.ToTable("Store_Detail");
                e.HasKey(e => new { e.Id_Product, e.Id_Store });

                e.HasOne(e => e.Store)
                .WithMany(e => e.store_Details)
                .HasForeignKey(e => e.Id_Store);


                e.HasOne(e => e.Product)
                .WithMany(e => e.store_Details)
                .HasForeignKey(e => e.Id_Product);


            });
   
    }    
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Store_Detail> Store_Details { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //   .AddJsonFile("appsettings.json")
                //   .Build();
                optionsBuilder.UseSqlServer("Server=VINH;Database=SchoolDBAPI;Trusted_Connection=True;user id =sa ; password =123");
            }
        }
    }
}
