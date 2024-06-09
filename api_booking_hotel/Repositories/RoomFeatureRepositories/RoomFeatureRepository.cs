
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.RoomFeatureRepositories
{
    public class RoomFeatureRepository : IRoomFeatureRepository
    {
        private readonly MyDbContext dbContext;

        public RoomFeatureRepository(MyDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> Create(int roomId, int[] featureId)
        {
            foreach (var item in featureId)
            {
                var check = await dbContext.RoomFeatures.FirstOrDefaultAsync(x => x.RoomId == item);
                if (check == null)
                {
                    var data = new RoomFeature
                    {
                        RoomId = roomId,
                        FeatureId = item,
                    };

                    await dbContext.RoomFeatures.AddAsync(data);
                }
            }
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await dbContext.RoomFeatures.FindAsync(id);
            if (data == null) return false;
            dbContext.RoomFeatures.Remove(data);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
