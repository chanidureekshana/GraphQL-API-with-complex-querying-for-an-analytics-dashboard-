using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Data.Entities
{
    public class Metric
    {
        public int MetricId { get;set; }
        public int UserId { get;set; }
        public string Name { get;set; }
        public double Value { get;set; }
        public DateTime RecordedAt { get;set; }
        public User User { get;set; }
    }
}