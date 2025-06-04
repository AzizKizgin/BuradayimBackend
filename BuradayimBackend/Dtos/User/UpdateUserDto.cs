using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Dtos.User
{
    public record UpdateUserDto
    {
        public string About { get; set; }
        public string ProfilePicture { get; set; }
    }
}