using AspireAppSock.ApiService.Common.Interfaces;
using AspireAppSock.ApiService.Domain.Models;
using AspireAppSock.ApiService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AspireAppSock.ApiService.Infrastructure.Repositorys;

public sealed class CustomerRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<Customer> logger) : GenericRepository<Customer>(dbContextFactory, logger), ICustomerRepository
{
}
