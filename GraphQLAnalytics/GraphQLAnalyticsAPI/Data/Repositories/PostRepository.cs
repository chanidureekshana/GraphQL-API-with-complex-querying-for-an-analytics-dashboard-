using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.DataContext;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.Data.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly SqlDbContext _context;

        public PostRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _context.Posts.FindAsync(postId);
        }

        public IQueryable<Post> GetPostsByUserId(int userId)
        {
            return _context.Posts.Where(p => p.UserId == userId);
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _context.Posts;
        }  
    }
}