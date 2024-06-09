namespace api_booking_hotel.Models
{
    public class HotelReview
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? HotelId { get; set; }
        public float Rating { get; set; }
        public string? Comment { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public User? User { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
