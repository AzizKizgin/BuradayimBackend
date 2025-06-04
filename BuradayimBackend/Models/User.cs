using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BuradayimBackend.Models
{
    public class User : IdentityUser
    {
        public string About { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public byte[]? ProfilePicture { get; set; }
        public List<Post> Posts { get; set; } = new();
        
    }
}