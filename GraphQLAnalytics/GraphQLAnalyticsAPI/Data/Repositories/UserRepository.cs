using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.DataContext;
using GraphQLAnalyticsAPI.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAnalyticsAPI.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly SqlDbContext _context ;
        public UserRepository(SqlDbContext context)
        {
            _context =context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeteleUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user != null)
            {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync( u=> u.UserId == userId);
            // var user =  await _context.Users.FindAsync(userId);
            // if (user ==null)
            // {
            //     return null;
            // }
            // return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }






    }
}