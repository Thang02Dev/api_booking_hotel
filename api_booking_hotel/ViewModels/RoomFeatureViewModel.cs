using api_booking_hotel.Models;

namespace api_booking_hotel.ViewModels
{
    public class RoomFeatureViewModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? FeatureId { get; set; }
        public RoomViewModel? RoomViewModel { get; set; }
        public FeatureViewModel? FeatureViewModel { get; set; }
    }
}
