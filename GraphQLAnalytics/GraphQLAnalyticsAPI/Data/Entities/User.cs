using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Data.Entities
{
    public class User
    {
        public int UserId { get;set; }
        public string Username { get;set; }
        public string Email  {set; get; }
        public string PasswordHash { get;set;}
        public string Role { get;set; }
        public DateTime CreatedAt { get;set; }
        public DateTime? LastLogin { get;set;}
        public ICollection<Metric>Metrics { get;set;}
        
    }
}