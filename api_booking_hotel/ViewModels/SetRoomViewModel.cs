using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class SetRoomViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên phòng không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Loại phòng không được bỏ trống")]
        public string Type { get; set; } = string.Empty;
        [Required(ErrorMessage = "Diện tích không được bỏ trống")]
        public int Size { get; set; }
        [Required(ErrorMessage = "Trạng thái không được bỏ trống")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "Số lượng giường không được bỏ trống")]
        public int NumberOfBeds { get; set; }
        [Required(ErrorMessage = "Số lượng khách không được bỏ trống")]
        public int NumberOfGuests { get; set; }
        [Required(ErrorMessage = "Giá phòng không được bỏ trống")]
        public float Price { get; set; }
        public string Slug { get; set; } = string.Empty;
        public int? Amount { get; set; }
        public int? HotelId { get; set; }
    }
}
