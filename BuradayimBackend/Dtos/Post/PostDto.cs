using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Dtos.User;

namespace BuradayimBackend.Dtos.Post
{
    public record PostDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Images { get; set; } = new();
        public UserDto User { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}