using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_booking_hotel.Models
{
    public class UtilityCategory
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "varchar(150)")]
        public string Slug { get; set; } = string.Empty;
        public List<Utility>? Utilities { get; set; }
    }
}
