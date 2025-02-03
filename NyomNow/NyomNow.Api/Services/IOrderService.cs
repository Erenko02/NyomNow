
namespace NyomNow.NyomNow.Api.Services
{
    using NyomNow.Api.Models;
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();  // ✅ Този метод трябва да съществува
        Task AddOrderAsync(Order order);
    }

}