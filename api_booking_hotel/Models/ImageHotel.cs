using api_booking_hotel.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.Models
{
    public class ImageHotel
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string? Image { get; set; }
        public bool Active { get; set; }
        public int Position { get; set; }
        public string? Description { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel{ get; set; }
    }
}
