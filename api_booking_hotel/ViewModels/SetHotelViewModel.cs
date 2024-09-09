using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class SetHotelViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên khách sạn không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone_Number { get; set; } = string.Empty;
        public string? Introduce { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string? CheckIn_Time { get; set; }
        public string? CheckOut_Time { get; set; }
        [Required(ErrorMessage = "Trạng thái không được bỏ trống")]
        public bool Active { get; set; }
        public float? Favorite { get; set; }
    }
}
