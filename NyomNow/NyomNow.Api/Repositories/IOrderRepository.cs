namespace NyomNow.NyomNow.Api.Repositories
{
    using NyomNow.Api.Models;
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}
