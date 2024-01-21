using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải nhiều hơn 6 ký tự")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Họ và tên không được bỏ trống")]
        public string Full_Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone_Number { get; set; } = string.Empty;
        [Required(ErrorMessage = "Chức vụ không được bỏ trống")]
        public bool Role { get; set; } //0:admin, 1:khach_hang
        [Required(ErrorMessage = "Giới tính không được bỏ trống")]
        public bool Gender { get; set; } //0:nam, 1:nu
    }
}
