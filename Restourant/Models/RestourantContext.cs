using Microsoft.EntityFrameworkCore;

namespace Restourant.Models;

public class RestourantContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<TotalRemainingOfProduct> TotalRemainings { get; set; }
    public DbSet<Order> Orders { get; set; }
    public RestourantContext(DbContextOptions<RestourantContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Users Table
        var userTable = modelBuilder.Entity<User>();
        userTable.HasKey(u => u.Id);
        userTable.Property(u => u.Username).IsRequired();
        userTable.HasIndex(u => u.Username).IsUnique();
        userTable.Property(u => u.PhoneNumber).HasColumnType("char(13)").IsRequired();
        userTable.HasIndex(u => u.PhoneNumber).IsUnique();
        userTable.HasMany(u => u.UserAdresses).WithOne(ua => ua.User).HasForeignKey(ua => ua.UserId);
        userTable.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);

        //Adresses Table
        var adressTable = modelBuilder.Entity<Adress>();
        adressTable.HasKey(u => u.Id);
        adressTable.Property(a => a.Region).IsRequired();
        adressTable.Property(a => a.Location).IsRequired();
        adressTable.HasMany(a => a.Orders).WithOne(a => a.Adress).HasForeignKey(a => a.AdressId);

        //Employees Table
        var employeeTable = modelBuilder.Entity<Employee>();
        employeeTable.HasKey(u => u.Id);
        employeeTable.Property(employeeTable => employeeTable.UserName).IsRequired();
        employeeTable.Property(e => e.CurrentSalary).IsRequired();
        employeeTable.HasIndex(e => e.UserName).IsUnique();
        

        // Categorys Table
        var categoryTable = modelBuilder.Entity<Category>();
        categoryTable.HasKey(c => c.Id);
        categoryTable.Property(c => c.Name).IsRequired();
        categoryTable.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

        //Products Table
        var productTable = modelBuilder.Entity<Product>();
        productTable.HasKey(c => c.Id);
        productTable.Property(p => p.Name).IsRequired();
        productTable.Property(p => p.ExpirationDate).IsRequired();
        productTable.Property(p => p.ProductionDate).IsRequired();
        productTable.Property(p => p.Name).IsRequired();
        
        productTable.HasOne(p => p.Total).WithOne(tr => tr.Product).HasForeignKey<TotalRemainingOfProduct>(t => t.ProductId);
        productTable.HasMany(p => p.OrderProducts).WithOne(op => op.Product).HasForeignKey(p => p.ProductId);

        //Orders Table
        var orderTable = modelBuilder.Entity<Order>();
        orderTable.HasKey(c => c.Id);
        orderTable.Property(o => o.CreatedTime).IsRequired();
        orderTable.Property(o => o.TotalPrice).IsRequired();
        
        orderTable.HasMany(o => o.OrderProducts).WithOne(op => op.Order).HasForeignKey(op => op.OrderId);

        //OrderProducts Table
        
        modelBuilder.Entity<OrderProduct>().Property(o => o.HowManyProduct).IsRequired();

        //TotalRemaingOfProducts Table
        
        modelBuilder.Entity<TotalRemainingOfProduct>().Property(x => x.TotalRemaining).IsRequired();


    }
}
