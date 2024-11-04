using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using GraphQLAnalyticsAPI.Data.Repositories;

namespace GraphQLAnalyticsAPI.GraphQL.Queries
{
    public class MetricQueries
    {
        public IQueryable<Metric>GetMetrics([Service] IMetricRepository metricRepository)
        {
            return (IQueryable<Metric>)metricRepository.GetAllMetricsAsync();
        }
        public IQueryable<Metric> GetUserById (int id , [Service] IMetricRepository metricRepository)
        {
            return (IQueryable<Metric>)metricRepository.GetMetricByIdAsync(id);
        }
    }
}