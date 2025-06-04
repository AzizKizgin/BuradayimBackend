using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Dtos.User
{
    public record LoginDto
    {
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress (ErrorMessage = "Email is not valid")]
        public string Email { get; init; }

        [Required (ErrorMessage = "Password is required")]
        public string Password { get; init; }
    }
}