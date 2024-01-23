using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_booking_hotel.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Address { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string Phone_Number { get; set; } = string.Empty;
        public string? Introduce { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Slug { get; set; } = string.Empty;
        public DateTime? CheckIn_Time { get; set; }
        public DateTime? CheckOut_Time { get; set; }
        public bool Active { get; set; }
        public float? Favorite { get; set; }
        public int? CategoryId { get; set; }
        public int? ImageHotelId { get; set; }
        public Category? Category { get; set; }
        public ImageHotel? ImageHotel { get; set; }
        public List<HotelUtility>? HotelUtilities { get; set; }
    }
}
