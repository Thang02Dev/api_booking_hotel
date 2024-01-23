using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_booking_hotel.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Full_Name { get; set; } = string.Empty;
        //[EmailAddress]
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; } = string.Empty;
        //[RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Column(TypeName = "varchar(10)")]
        public string Phone_Number { get; set; } = string.Empty;
        [Column(TypeName = "varchar(200)")]
        public string Password { get; set; } = string.Empty;
        public bool Role { get; set; } //0:admin, 1:khach_hang
        public bool Gender { get; set; } //0:nam, 1:nu
        [MaxLength(200)]
        public string? City { get; set; } = string.Empty;
        [Required]
        public bool Active { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Updated_Date { get; set; }
    }
}
