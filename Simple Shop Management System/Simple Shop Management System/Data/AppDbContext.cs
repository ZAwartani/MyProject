using Microsoft.EntityFrameworkCore;
using Simple_Shop_Management_System.Models;

namespace Simple_Shop_Management_System.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Select Category"},
            new Category() { Id = 2, Name = "Vegetables" },
            new Category() { Id = 3, Name = "Fruits" },
            new Category() { Id = 4, Name = "Meats" }
        );
        base.OnModelCreating(modelBuilder);
    }
}
