
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_booking_hotel.ViewModels
{
    public class UtilityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên tiện ích không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        public int? UtilityCategoryId { get; set; }
        
        public UtilityCategoryViewModel? UtilityCategoryViewModel { get; set; }
    }
}
