using System.ComponentModel.DataAnnotations;

namespace WMS.Service.Dtos.User
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")] 
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password name is required")] 
        public string Password { get; set; } = null!;
    }
}
