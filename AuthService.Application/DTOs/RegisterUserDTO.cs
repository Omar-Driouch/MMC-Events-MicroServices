using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public class RegisterUserDTO
    {
        [Required,MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required,MinLength(8)]
        public string Password { get; set; }  = string.Empty;
        [Required, Compare("Password")]
        public string PasswordConfirmation { get; set; }  = string.Empty;

    }
}
