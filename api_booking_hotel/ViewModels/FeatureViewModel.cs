using api_booking_hotel.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_booking_hotel.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; } = string.Empty;
        //[JsonIgnore]
        //public List<RoomFeatureViewModel>? RoomFeatureViewModels { get; set; }
    }
}
