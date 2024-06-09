namespace api_booking_hotel.ViewModels
{
    public class ImageRoomPagin
    {
        public List<ImageRoomViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
