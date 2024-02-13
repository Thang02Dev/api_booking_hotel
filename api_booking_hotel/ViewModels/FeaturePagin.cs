namespace api_booking_hotel.ViewModels
{
    public class FeaturePagin
    {
        public List<FeatureViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
