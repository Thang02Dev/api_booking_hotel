using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class UtilityCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên thể loại không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
