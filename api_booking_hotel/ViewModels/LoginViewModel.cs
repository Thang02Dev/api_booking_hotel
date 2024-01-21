using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage ="Email không được bỏ trống")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get; set; } = string.Empty;
    }
}
