using api_booking_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.DBContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ImageHotel> ImageHotels { get; set; }
        public DbSet<UtilityCategory> UtilityCategories { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<HotelUtility> HotelUtilities { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<ImageRoom> ImageRooms { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
