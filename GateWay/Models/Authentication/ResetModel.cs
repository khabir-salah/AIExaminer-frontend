using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.ClientAI.Models.Authentication
{
    public class ResetModel
    {
        public class ForgotPasswordRequest
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public class ResetPasswordRequest
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            [Compare(nameof(Password))]
            public string ConfirmPassword { get; set; }
            [Required]
            public string Token { get; set; }
        }
    }
}
