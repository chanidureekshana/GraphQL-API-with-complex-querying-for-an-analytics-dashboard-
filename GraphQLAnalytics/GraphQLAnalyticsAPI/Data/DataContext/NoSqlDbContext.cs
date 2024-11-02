using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using MongoDB.Driver;

namespace GraphQLAnalyticsAPI.Data.DataContext
{
    public class NoSqlDbContext
    {
        private readonly IMongoDatabase _database;
        public NoSqlDbContext(string connectionString , string databaseName )
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<User>Users=>_database.GetCollection<User>("Users");
        public IMongoCollection<Metric>Metrics=>_database.GetCollection<Metric>("Metrics");
        public IMongoCollection<Event> Events =>_database.GetCollection<Event>("Events");
    }
}