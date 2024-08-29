namespace AspireAppSock.ApiService.Domain.Models;

public class SalesReport
{
    public DateTime ReportDate
    {
        get; set;
    }
    public decimal TotalSales
    {
        get; set;
    }
    public decimal TotalProfit
    {
        get; set;
    }

    public SalesReport GenerateReport(List<Order> orders)
    {
        return new SalesReport
        {
            ReportDate = DateTime.Now,
            TotalSales = orders.Sum(o => o.TotalAmount),
            TotalProfit = orders.Sum(o => o.TotalAmount) * 0.2m // Przykład: 20% marży
        };
    }
}
