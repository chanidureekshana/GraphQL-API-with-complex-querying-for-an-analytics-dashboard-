using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Data.Entities
{
    public class Role
    {
        public int RoleId  { get;set; }
        public string Name { get;set; }
        public ICollection<User>User { get;set ;}
    }
}