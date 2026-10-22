using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class LoginUser
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
