using System.ComponentModel.DataAnnotations;

namespace Steve.Model
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter the User name/Email")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter the Password")]
        public string Password { get; set; }
    }
}
