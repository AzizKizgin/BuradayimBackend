using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Dtos.User
{
    public record RegisterDto
    {
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress (ErrorMessage = "Email is not valid")]
        public string Email { get; init; }

        [Required (ErrorMessage = "Username is required")]
        [MinLength(1, ErrorMessage = "Username must not be empty")]
        [MaxLength(20, ErrorMessage = "Username must not be longer than 20 characters")]
        public string Username { get; init; }

        [Required (ErrorMessage = "Password is required")]
        public string Password { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.Now;
    }
}