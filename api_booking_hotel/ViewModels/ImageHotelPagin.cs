namespace api_booking_hotel.ViewModels
{
    public class ImageHotelPagin
    {
        public List<ImageHotelViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
