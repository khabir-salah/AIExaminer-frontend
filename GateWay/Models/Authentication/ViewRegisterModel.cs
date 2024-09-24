using System.ComponentModel.DataAnnotations;

namespace Gateway.Models.Authentication
{
    public  class ViewRegisterModel
    {
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string RepeatPassword { get; set; } = default!;
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
    }

    public class LoginRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
