using api_booking_hotel.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_booking_hotel.ViewModels
{
    public class ImageRoomViewModel
    {
        public int Id { get; set; }
        
        public string? Image { get; set; } = string.Empty;
        [Required(ErrorMessage ="Trạng thái không được bỏ trống")]
        public bool Active { get; set; }
        [Required(ErrorMessage ="Thứ tự vị trí không được bỏ trống")]
        public int Position { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int? RoomId { get; set; }
        //[JsonIgnore]
        //public RoomViewModel? RoomViewModel { get; set; }
    }
}
