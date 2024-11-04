using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.Data.Repositories
{
    public interface IMetricRepository
    {
        Task<Metric> GetMetricByIdAsync(int metricId);
        Task<IEnumerable<Metric>> GetAllMetricsAsync();
        Task<Metric> AddMetricAsync(Metric metric);
        Task<Metric> UpdateMetricAsync(Metric metric);
        Task<bool> DeleteMetricAsync(int metricId);
    }
}