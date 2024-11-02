using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;

namespace GraphQLAnalyticsAPI.Services
{
    public interface IMetricService
    {
        Task<Metric> GetMetricByIdAsync (int metricId);
        Task<IEnumerable<Metric>> GetAllMetricAsync();
        Task<Metric>CreateMetricAsync(Metric metric);
        Task<bool> UpdateMetricAsync(Metric metric);
        Task<bool>  DeleteMetricAsync(int metricId);
    }
}