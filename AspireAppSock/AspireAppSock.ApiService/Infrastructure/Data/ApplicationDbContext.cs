using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using AspireAppSock.ApiService.Domain.Models;

namespace AspireAppSock.ApiService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
      
    }

    public DbSet<Customer> CustomerLists => Set<Customer>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

  

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
