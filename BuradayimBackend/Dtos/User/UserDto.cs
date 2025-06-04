using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Dtos.User
{
    public record UserDto
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public string Username { get; init; }
        public string About { get; init; }
        public DateTime CreatedAt { get; init; }
        public string ProfilePicture { get; init; }
        public string? Token { get; set; }
    }
}