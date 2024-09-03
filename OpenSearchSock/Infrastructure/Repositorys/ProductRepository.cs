using OpenSearchSock.Common.Interfaces;
using OpenSearchSock.Domain.Models;
using OpenSearchSock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OpenSearchSock.Infrastructure.Repositorys;

public sealed class ProductRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory,ILogger<Product> logger) : GenericRepository<Product>(dbContextFactory, logger), IProductRepository
{
}
