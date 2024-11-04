using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.Entities;
using GraphQLAnalyticsAPI.Data.Repositories;

namespace GraphQLAnalyticsAPI.GraphQL.Mutations
{
    public class MetricMutations
    {
        public async Task<Metric> CreateMetricAsync(Metric metric , [Service] IMetricRepository metricRepository)
        {
            return await metricRepository.AddMetricAsync(metric);
        }

    
        public async Task<Metric>UpdateMetricAsync(int id ,Metric updatedMetric , [Service] IMetricRepository metricRepository)
        {
            var metric = await metricRepository.GetMetricByIdAsync(id);
            if(metric == null) return null;
            metric.Name = updatedMetric.Name;
            metric.Value = updatedMetric.Value;

            return await metricRepository.UpdateMetricAsync(metric);
        }
        public async Task<bool> DeleteMetricAsync(int id , [Service] IMetricRepository metricRepository)
        {
            return await metricRepository.DeleteMetricAsync(id);
        }
    }
}