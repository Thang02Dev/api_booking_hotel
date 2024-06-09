namespace api_booking_hotel.ViewModels
{
    public class RoomPagin
    {
        public List<RoomViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
