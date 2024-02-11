namespace api_booking_hotel.ViewModels
{
    public class UtilityPagin
    {
        public List<UtilityViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
