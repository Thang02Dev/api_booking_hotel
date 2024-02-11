using api_booking_hotel.Models;
using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class HotelUtilityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tiện ích chính không được bỏ trống")]
        public bool Main { get; set; }
        public int? UtilityId { get; set; }
        public int? HotelId { get; set; }
        public UtilityViewModel? UtilityViewModel { get; set; }
        public HotelViewModel? HotelViewModel { get; set; }
    }
}
