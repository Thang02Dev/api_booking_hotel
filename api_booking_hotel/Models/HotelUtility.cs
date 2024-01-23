namespace api_booking_hotel.Models
{
    public class HotelUtility
    {
        public int Id { get; set; }
        public bool Main { get; set; }
        public int? UtilityId { get; set; }
        public int? HotelId { get; set; }
        public Utility? Utility { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
