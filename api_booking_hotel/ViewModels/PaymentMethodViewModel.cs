using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class PaymentMethodViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên phương thức thanh toán không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="Mô tả không được bỏ trống")]
        public string Description { get; set; } = string.Empty;
    }
}
