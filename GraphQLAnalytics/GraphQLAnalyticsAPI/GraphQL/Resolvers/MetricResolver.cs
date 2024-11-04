// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using GraphQLAnalyticsAPI.Data.Repositories;

// namespace GraphQLAnalyticsAPI.GraphQL.Resolvers
// {
//     public class MetricResolver
//     {
//         public async Task<int> GetAverageMetricAsync(int userId , [Service] IMetricRepository metricRepository)
//         {
//             var metrics =await metricRepository.GetMetricByIdAsync(userId);
//             // return metrics.Average(m => m.Value);
//         }
//     }
// }