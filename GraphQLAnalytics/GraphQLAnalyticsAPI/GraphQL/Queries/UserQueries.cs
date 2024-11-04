using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using GraphQLAnalyticsAPI.Data.Repositories;
using GraphQLAnalyticsAPI.Services;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLAnalyticsAPI.GraphQL.Queries
{
    public class UserQueries
    {
        public IQueryable<User> GetUsers ([Service] IUserRepository userRepository)
        {
            return (IQueryable<User>)userRepository.GetAllUsersAsync();
        }
        public IQueryable<User> GetUserById(int userId, [Service] IUserRepository userRepository)
        {
            return (IQueryable<User>)userRepository.GetUserByIdAsync(userId);
        } 
        // public User GetUserById(int userId, [Service] IUserRepository userRepository)
        // {
            // return userRepository.GetUserByIdAsync(userId);
        // }
    
    }


}