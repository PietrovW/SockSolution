namespace AspireAppSock.ApiService.Domain.Models;

public record Order
{
    public required long OrderId
    {
        get; init;
    }
    public required long CustomerId
    {
        get; init;
    }
    public required DateTime OrderDate
    {
        get; init;
    }
    public required List<OrderItem> Items
    {
        get; init;
    }
    public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
}
