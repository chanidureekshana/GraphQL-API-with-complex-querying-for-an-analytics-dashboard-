using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAnalyticsAPI.Data.DataContext
{
    public class SqlDbContext:DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Post>Posts { get;set;}
        public DbSet<Role> Roles { get; set; }
    }
}