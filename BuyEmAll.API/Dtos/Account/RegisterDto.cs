using System.ComponentModel.DataAnnotations;

namespace BuyEmAll.API.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        // [RegularExpression("")]
        public string Password { get; set; }
    }
}