namespace AspireAppSock.ApiService.Domain.Models;

public record OrderItem
{
    public required long ProductId
    {
        get; init;
    }
    public required long Quantity
    {
        get; init;
    }
    public required decimal UnitPrice
    {
        get; init;
    }
    public decimal TotalPrice => Quantity * UnitPrice;
}
