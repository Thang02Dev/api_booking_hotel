﻿using System.ComponentModel.DataAnnotations;

namespace api_booking_hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;
        public int Size  { get; set; }
        public bool Active { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfQuests { get; set; }
        public float Price { get; set; }
        public int? Amount { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public List<RoomFeature>? RoomFeatures { get; set; }
        public List<ImageRoom>? ImageRooms { get; set; }

    }
}
