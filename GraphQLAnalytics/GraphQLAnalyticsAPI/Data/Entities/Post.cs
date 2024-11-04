using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAnalyticsAPI.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }       // Unique ID of the post
        public int UserId { get; set; }       // ID of the user who created the post
        public string Title { get; set; }     // Title of the post
        public string Content { get; set; }   // Content/body of the post
        public DateTime CreatedDate { get; set; }   // Date when the post was created
        public DateTime? UpdatedDate { get; set; } 
    }
}