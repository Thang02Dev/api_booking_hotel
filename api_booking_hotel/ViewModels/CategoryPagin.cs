namespace api_booking_hotel.ViewModels
{
    public class CategoryPagin
    {
        public List<CategoryViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
