using Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Logging.LogFormats;
using Adisyon_OnionArch.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Adisyon_OnionArch.Project.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<LogDetailWithException> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configrasyonları Assmbly olarak implament eder..
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // APPSETTİNGSTEN ÇEKEREKN BİR SIKINTI OLUYOR ALTERNATİF ÇÖZÜM OLARAK YAPILDI.
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=EGE_SAMUR\\SQLEXPRESS;Database=adisyonDb;Integrated Security=True;TrustServerCertificate=True;");
        //    }
        //}

    }
}
