using GraphQLAnalyticsAPI.Data.Entities;
using GraphQLAnalyticsAPI.Data.Repositories;
using HotChocolate;

namespace GraphQLAnalyticsAPI.GraphQL.Mutations
{
    public class UserMutations
    {
        public async Task<User>CreateUserAsync(User user , [Service] IUserRepository userRepository)
        {
            return await userRepository.AddUserAsync(user);
        }

        public async Task<User> UpdateUserAsync(int id , User updateUser, IUserRepository userRepository)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            if(user==null) return null;

            user.Username = updateUser.Username;
            user.Email = updateUser.Email;

            return await userRepository.UpdateUserAsync(user);
        }
        public async Task<bool> DeleteUserAsync(int id , [Service] IUserRepository userRepository)
        {
            return await userRepository.DeteleUserAsync(id);
        }
    }
}