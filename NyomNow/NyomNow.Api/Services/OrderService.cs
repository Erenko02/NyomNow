using System.Collections.Generic;
using System.Threading.Tasks;
using NyomNow.NyomNow.Api.Models;
using NyomNow.NyomNow.Api.Repositories;
using NyomNow.NyomNow.Api.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()  // ✅ Методът трябва да съществува
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task AddOrderAsync(Order order)
    {
        await _orderRepository.AddOrderAsync(order);
    }
}
