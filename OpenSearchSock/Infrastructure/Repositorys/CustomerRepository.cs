using OpenSearchSock.Common.Interfaces;
using OpenSearchSock.Domain.Models;
using OpenSearchSock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OpenSearchSock.Infrastructure.Repositorys;

public sealed class CustomerRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<Customer> logger) : GenericRepository<Customer>(dbContextFactory, logger), ICustomerRepository
{
}
