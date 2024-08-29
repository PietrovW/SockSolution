namespace AspireAppSock.ApiService.Domain.Models;

public record Customer
{
    public required long CustomerId
    {
        get; init;
    }
    public required string FirstName
    {
        get; init;
    }
    public required string LastName
    {
        get; init;
    }
    public required string Email
    {
        get; init;
    }
    public required string PhoneNumber
    {
        get; set;
    }
    public required List<Order> Orders
    {
        get; init;
    }
}
