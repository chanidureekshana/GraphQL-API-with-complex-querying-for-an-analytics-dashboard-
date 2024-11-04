using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using GraphQLAnalyticsAPI.Data.Repositories;
using HotChocolate.Authorization;

namespace GraphQLAnalyticsAPI.GraphQL.Resolvers
{
    public class UserResolver
    {
        // private readonly IUserRepository _user; 
        // private readonly IPostRepository _post;
        // public UserResolver(IUserRepository userRepository, IPostRepository postRepository)
        // {
        //     _user = userRepository;
        //     _post = postRepository;
        // }
        // public async Task<int> GetTotalPostsAsync(User user, [Service] IPostRepository postRepository)
        // {
        //     var posts = await postRepository.GetPostsByUserId(user.UserId);
        //     return posts.Count();
        // }
        public IQueryable<Post> GetPosts(User user, [Service] IPostRepository postRepository)
        {
            return postRepository.GetPostsByUserId(user.UserId);
        }  
        [Authorize]  // This requires users to be authenticated to access this query
        public async Task<User> GetUserByIdAsync(int userId, [Service] IUserRepository userRepository)
        {
            return await userRepository.GetUserByIdAsync(userId);
        }
        
        [Authorize(Roles = new[] { "Admin" })]  // Only "Admin" role can access this
        public async Task<List<User>> GetAllUsersAsync([Service] IUserRepository userRepository)
        {
            return (List<User>)await userRepository.GetAllUsersAsync();
        }
  
    }
}