using api_booking_hotel.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_booking_hotel.ViewModels
{
    public class ImageHotelViewModel
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "Trạng thái không được bỏ trống")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "Vị trí không được bỏ trống")]
        public int Position { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }
        //[JsonIgnore]
        //public HotelViewModel? HotelViewModel { get; set; }
    }
}
