using api_booking_hotel.Models;

namespace api_booking_hotel.ViewModels
{
    public class ManyImageHotel
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? ImageHotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public ImageHotel? ImageHotel { get; set; }
    }
}
