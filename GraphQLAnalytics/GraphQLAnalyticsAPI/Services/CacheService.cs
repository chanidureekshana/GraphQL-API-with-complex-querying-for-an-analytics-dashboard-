// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Caching.Distributed;
// using MongoDB.Bson.IO;
// // using MongoDB.Bson.IO;
// using Newtonsoft.Json;

// namespace GraphQLAnalyticsAPI.Services
// {
//     public class CacheService
//     {
//         private readonly IDistrubutedCache _cache;
//         public CacheService(IDistrubutedCache cache)
//         {
//             _cache =cache;
//         }
//         public async Task SetCacheAsync<T>(string key, T value, int expirationInMinutes)
//         {
//             var serializedValue = JsonConvert.SerializeObject(value);
//             var options = new DistributedCacheEntryOptions
//             {
//                 AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expirationInMinutes)
//             };
//             await _cache.SetStringAsync(key, serializedValue, options);
//         }

//         public async Task<T> GetCacheAsync<T>(string key)
//         {
//             var serializedValue = await _cache.GetStringAsync(key);
//             return serializedValue == null ? default : JsonConvert.DeserializeObject<T>(serializedValue);
//         }
//     }
// }