namespace AspireAppSock.ApiService.Domain.Models;

public sealed record Warehouse
{
    public required long WarehouseId
    {
        get; init;
    }
    public required string Location
    {
        get; init;
    }
    public required List<Product> Products
    {
        get; init;
    }

    public void UpdateStock(int productId, int quantity)
    {
        var product = Products.FirstOrDefault(p => p.ProductId == productId);
        if (product != null)
        {
            //product.StockQuantity += quantity;
        }
    }
}
