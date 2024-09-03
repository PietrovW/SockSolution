using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AspireAppSock.ApiService.Domain.Models;
using AspireAppSock.ApiService.Infrastructure.Data.Configurations;

namespace AspireAppSock.ApiService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Customer> CustomerLists
    {
        get; set;
    }
    //public DbSet<Order> OrderLists
    //{
    //    get; set;
    //}
    //public DbSet<OrderItem> OrderItemLists
    //{
    //    get; set;
    //}
    public DbSet<Product> ProductLists
    {
        get; set;
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
