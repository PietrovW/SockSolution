using OpenSearchSock.Domain.Models;
using Bogus;

namespace OpenSearchSock.Infrastructure.Data;

public static class ApplicationDbContextSeed
{
    private static long customerId = 1;
    private static long productId = 1;
    private static readonly Faker<Customer> fakeCustomerData = new Faker<Customer>()
        .RuleFor(p => p.CustomerId, f => customerId++)
            .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
            .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber("(###)-###-####"))
            .RuleFor(p => p.FirstName, f => f.Name.FirstName(f.Person.Gender))
            .RuleFor(p => p.LastName, f => f.Name.LastName(f.Person.Gender))
            .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName));

    private static readonly Faker<Product> fakeProductData = new Faker<Product>()
        .RuleFor(p => p.ProductId, f => productId++)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Color, f => f.Commerce.Color())
            .RuleFor(p => p.EAN, f => f.Commerce.Ean13())
            .RuleFor(p => p.Material, f => f.Commerce.ProductMaterial())
            .RuleFor(p => p.StockQuantity, f => f.Random.Short(0, 100))
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1, 1000, 4)))
            .RuleFor(p => p.Category, f => f.Commerce.Categories(10).GetValue(f.Random.Short(1, 5)));

    public static async Task SeedSampleData(this ApplicationDbContext context)
    {
        if (context.CustomerLists.Any())
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
        if (!context.CustomerLists.Any())
        {
            var users = fakeCustomerData.Generate(count: 1000);
            context.CustomerLists.AddRange(users);
            context.SaveChanges();
        }

        if (!context.ProductLists.Any())
        {
            try
            {

                var products = fakeProductData.Generate(count: 1000);
                context.ProductLists.AddRange(products);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
