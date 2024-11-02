using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
// using Gra
namespace GraphQLAnalyticsAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<bool>UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}