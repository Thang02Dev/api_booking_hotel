namespace api_booking_hotel.Models
{
    public class ImageRoom
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public bool Active { get; set; }
        public int Position { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
