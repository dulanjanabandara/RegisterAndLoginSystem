using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegisterAndLoginSystem.Models
{
    public class LoginUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
    }
}