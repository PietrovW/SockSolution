namespace AspireAppSock.ApiService.Domain.Models;

public sealed record Product
{
    public required long ProductId
    {
        get; init;
    }
    public required string Name
    {
        get; init;
    }
    public required string Category
    {
        get; init;
    }
    public required string Size
    {
        get; init;
    }
    public required string Color
    {
        get; init;
    }
    public required string Material
    {
        get; init;
    }
    public required decimal Price
    {
        get; init;
    }
    public required int StockQuantity
    {
        get; init;
    }
}
