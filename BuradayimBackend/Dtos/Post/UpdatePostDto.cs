using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Dtos.Post
{
    public record UpdatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Images { get; set; } = new();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}