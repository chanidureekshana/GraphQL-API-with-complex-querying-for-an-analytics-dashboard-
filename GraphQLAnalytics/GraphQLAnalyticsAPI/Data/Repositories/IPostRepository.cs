using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.Data.Repositories
{
    public interface IPostRepository
    {
        Task<Post> AddPostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(int postId);
        Task<Post> GetPostByIdAsync(int postId);
        IQueryable<Post> GetPostsByUserId(int userId);
        IQueryable<Post> GetAllPosts();
    }
}