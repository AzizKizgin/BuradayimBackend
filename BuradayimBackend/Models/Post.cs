using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<byte[]> Images { get; set; } = new();
        public string UserId { get; set; }
        public User User { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}