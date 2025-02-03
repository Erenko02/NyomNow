namespace NyomNow.NyomNow.Api.Services
{
    using NyomNow.Api.Models;
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
    }
}
