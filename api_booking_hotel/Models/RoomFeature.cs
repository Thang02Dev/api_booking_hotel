namespace api_booking_hotel.Models
{
    public class RoomFeature
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? FeatureId { get; set; }
        public Room? Room { get; set; }
        public Feature? Feature { get; set; }
    }
}
