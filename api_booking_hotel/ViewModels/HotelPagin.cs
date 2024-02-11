namespace api_booking_hotel.ViewModels
{
    public class HotelPagin
    {
        public List<HotelViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
