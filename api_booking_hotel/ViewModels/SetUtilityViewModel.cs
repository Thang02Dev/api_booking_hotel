using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class SetUtilityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên tiện ích không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        public int? UtilityCategoryId { get; set; }
    }
}
