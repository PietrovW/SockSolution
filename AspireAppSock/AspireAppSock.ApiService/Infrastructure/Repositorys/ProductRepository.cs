using AspireAppSock.ApiService.Common.Interfaces;
using AspireAppSock.ApiService.Domain.Models;
using AspireAppSock.ApiService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AspireAppSock.ApiService.Infrastructure.Repositorys;

public sealed class ProductRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory,ILogger<Product> logger) : GenericRepository<Product>(dbContextFactory, logger), IProductRepository
{
}
