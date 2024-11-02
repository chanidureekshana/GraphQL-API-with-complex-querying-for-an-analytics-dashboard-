using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.DataContext;
using GraphQLAnalyticsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAnalyticsAPI.Services
{
    public class UserService:IUserService
    {
        private readonly SqlDbContext _context;
        public UserService(SqlDbContext context)
        {
            _context=context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user ==null)return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;

        }
    } 
}