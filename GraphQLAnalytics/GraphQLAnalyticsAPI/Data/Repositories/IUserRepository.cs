using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User>GetUserByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync (User user);
        Task<User> UpdateUserAsync (User user);
        Task<bool> DeteleUserAsync (int userId);
    }
}