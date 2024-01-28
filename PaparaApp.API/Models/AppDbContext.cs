using Microsoft.EntityFrameworkCore;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Definitions;
using PaparaApp.API.Models.ProductFeatures;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Users;

namespace PaparaApp.API.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }


    public DbSet<ProductFeature> ProductFeatures { get; set; }

    public DbSet<ProductDefinition> ProductDefinitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure Fluent API
        // table oluşturmak
        //modelBuilder.Entity<User>().ToTable("UserTb")

        // one to many
        //modelBuilder.Entity<Product>().HasKey(p => p.Product_Id);

        //modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

        //modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

        //modelBuilder.Entity<User>().HasMany(x => x.Products).WithOne(x => x.User).HasForeignKey(x => x.UserId);


        modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);

        base.OnModelCreating(modelBuilder);
    }
}