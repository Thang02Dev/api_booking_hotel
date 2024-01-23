using api_booking_hotel.Models;
using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên danh mục không được bỏ trống")]
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Icon { get; set; }
        [Required(ErrorMessage = "Thứ tự vị trí không được bỏ trống")]
        public int Position { get; set; }
        [Required(ErrorMessage = "Trạng thái không được bỏ trống")]
        public bool Active { get; set; }
        //public List<Hotel>? Hotels { get; set; }
    }
}
