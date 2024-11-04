using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Services
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken (string userId , string username);
    }
}