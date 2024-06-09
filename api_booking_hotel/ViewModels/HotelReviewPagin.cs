namespace api_booking_hotel.ViewModels
{
    public class HotelReviewPagin
    {
        public List<HotelReviewViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
