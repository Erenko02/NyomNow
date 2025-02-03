namespace NyomNow.NyomNow.Api.Business
{
    public interface IBusinessService
    {
        Task<int> GetTotalOrdersAsync();
        Task<double> CalculateTotalRevenueAsync();
    }
}