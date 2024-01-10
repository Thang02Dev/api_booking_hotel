using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.DBContext
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
