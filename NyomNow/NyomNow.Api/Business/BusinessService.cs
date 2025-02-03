namespace NyomNow.NyomNow.Api.Business
{
    using NyomNow.Api.Services;

    public class BusinessService : IBusinessService
    {
        private readonly IOrderService _orderService;

        public BusinessService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return orders.Count();
        }

        public async Task<double> CalculateTotalRevenueAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return orders.Sum(o => o.TotalAmount);
        }
    }
}