using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.DataContext;
using GraphQLAnalyticsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAnalyticsAPI.Data.Repositories
{
    public class MetricRepository
    {
        private readonly SqlDbContext _context;
        public MetricRepository(SqlDbContext context)
        {
            _context= context;
        }
        public async Task<Metric> GetMetricByIdAsync(int metricId)
        {
            return await _context.Metrics.FindAsync(metricId);
        }

        public async Task<IEnumerable<Metric>> GetAllMetricsAsync()
        {
            return await _context.Metrics.ToListAsync();
        }

        public async Task<Metric> AddMetricAsync(Metric metric)
        {
            _context.Metrics.Add(metric);
            await _context.SaveChangesAsync();
            return metric;
        }

        public async Task<Metric> UpdateMetricAsync(Metric metric)
        {
            _context.Metrics.Update(metric);
            await _context.SaveChangesAsync();
            return metric;
        }

        public async Task<bool> DeleteMetricAsync(int metricId)
        {
            var metric = await _context.Metrics.FindAsync(metricId);
            if (metric != null)
            {
                _context.Metrics.Remove(metric);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}