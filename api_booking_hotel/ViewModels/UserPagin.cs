﻿namespace api_booking_hotel.ViewModels
{
    public class UserPagin
    {
        public List<UserViewModel> Data { get; set; } = [];
        public int Count { get; set; }
        public int Current { get; set; }
    }
}
