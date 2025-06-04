using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Dtos.User
{
    public class ChangePasswordDto
    {
        [Required (ErrorMessage = "Old password is required")]
        public string OldPassword { get; set; }
        [Required (ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

    }
}