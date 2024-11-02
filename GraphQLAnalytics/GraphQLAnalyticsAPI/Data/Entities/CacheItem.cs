using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Data.Entities
{
    public class CacheItem
    {
        public string CacheKey { get;set; }
        public string Date { get;set ;}
        public DateTime CreatedAt { get;set;}
        public DateTime Expiration { get;set; }

    }
}