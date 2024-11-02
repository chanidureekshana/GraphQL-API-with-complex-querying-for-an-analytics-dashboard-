using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Data.Entities
{
    public class Event
    {
        public int EventId { get;set; }
        public string EventType { get;set; }
        public DateTime TimeStamp { get;set;}
        public int? UserId {get;set; }
        public string Details { get;set; }
        public User User { get;set; }
    }
}