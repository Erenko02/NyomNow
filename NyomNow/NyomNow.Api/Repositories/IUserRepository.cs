namespace NyomNow.NyomNow.Api.Repositories
{
    using NyomNow.Api.Models;

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
    }
}
