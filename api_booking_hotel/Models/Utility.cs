namespace api_booking_hotel.Models
{
    public class Utility
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? UtilityCategoryId { get; set; }
        public UtilityCategory? UtilityCategory { get; set; }
        public List<HotelUtility>? HotelUtilities { get; set; }
    }
}
