using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
