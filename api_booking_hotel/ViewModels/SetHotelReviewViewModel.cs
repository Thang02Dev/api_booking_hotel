using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class SetHotelReviewViewModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? HotelId { get; set; }
        [Required(ErrorMessage = "Điểm đánh giá không được bỏ trống")]
        public float Rating { get; set; }
        public string? Comment { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
    }
}
