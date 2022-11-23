using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Application.Dto.Admin
{
    public class CreateAdminDto
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [RegularExpression(
            "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$",
            ErrorMessage =
            "Password must contain at least one uppercase letter, one lowercase letter, one number and can't be shorter than 8 characters."
        )]
        public string Password { get; set; } = string.Empty;
        public bool CanManageAdmins { get; set; }
    }
}