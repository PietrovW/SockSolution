namespace OpenSearchSock.Domain.Models;

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
        get; init;
    }
    //public required List<Order> Orders
    //{
      //  get; init;
    //}

    public required Gender Gender
    {
        get; init;
    }
}

