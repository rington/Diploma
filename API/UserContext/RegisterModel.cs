using System.ComponentModel.DataAnnotations;

namespace API.UserContext
{
    public class RegisterModel
    {
        [Required] 
        public string Email { get; set; }

        [Required]        
        [MinLength(6)]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]        
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords does not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
