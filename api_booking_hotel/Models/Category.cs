using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_booking_hotel.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "varchar(150)")]
        public string Slug { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        public string? Icon { get; set; }
        public int Position { get; set; }
        public bool Active { get; set; }
        public List<Hotel>? Hotels { get; set; }
    }
}
