using System.Linq;
using System.Threading.Tasks;
using NyomNow.NyomNow.Api.Services;

public class OrderBusinessService : IOrderBusinessService
{
    private readonly IOrderService _orderService;

    public OrderBusinessService(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<int> GetTotalOrdersAsync()
    {
        var orders = await _orderService.GetOrdersAsync();
        return orders.Count();
    }

    public async Task<double> CalculateTotalRevenueAsync()
    {
        var orders = await _orderService.GetOrdersAsync();
        return orders.Sum(o => o.TotalAmount);
    }
}