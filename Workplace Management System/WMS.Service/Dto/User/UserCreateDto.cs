using System.ComponentModel.DataAnnotations;

namespace WMS.Service.Dto.User
{
    public class UserCreateDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = String.Empty;
    }
}
