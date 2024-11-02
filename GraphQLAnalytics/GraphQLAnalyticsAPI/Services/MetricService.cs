using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLAnalyticsAPI.Data.DataContext;
using GraphQLAnalyticsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAnalyticsAPI.Services
{
    public class MetricService:IMetricService
    {
        private readonly SqlDbContext _context; 
        public MetricService(SqlDbContext context)
        {
            _context =context;
        }

        public async Task<Metric> CreateMetricAsync(Metric metric)
        {
            _context.Metrics.Add(metric);
            await _context.SaveChangesAsync();
            return metric;
        }

        public async Task<bool> DeleteMetricAsync(int metricId)
        {
            var metric = await _context.Metrics.FindAsync(metricId);
            if(metric == null) return false;
            _context.Metrics.Remove(metric);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<IEnumerable<Metric>> GetAllMetricAsync()
        {
            return await _context.Metrics.ToListAsync();
        }

        public async Task<Metric> GetMetricByIdAsync(int metricId)
        {
            return await _context.Metrics.FindAsync(metricId);
        }

        public async Task<bool> UpdateMetricAsync(Metric metric)
        {
            _context.Metrics.Update(metric);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}