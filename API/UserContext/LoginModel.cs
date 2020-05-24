using System.ComponentModel.DataAnnotations;

namespace API.UserContext
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
