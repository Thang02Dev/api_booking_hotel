using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_booking_hotel.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        public string? Icon { get; set; } = string.Empty;
        public List<RoomFeature>? RoomFeatures { get; set; }

    }
}
