namespace NyomNow.NyomNow.Api.Services
{
    using System.Threading.Tasks;

    public interface IOrderBusinessService
    {
        Task<int> GetTotalOrdersAsync();
        Task<double> CalculateTotalRevenueAsync();
    }
}
