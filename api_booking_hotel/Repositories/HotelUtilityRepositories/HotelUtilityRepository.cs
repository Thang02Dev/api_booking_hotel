using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.HotelUtilityRepositories
{
    public class HotelUtilityRepository : IHotelUtilityRepository
    {
        private readonly MyDbContext dbContext;

        public HotelUtilityRepository(MyDbContext _dbContext) 
        {
            dbContext = _dbContext;
        }

        public async Task<bool?> ChangedMain(int id)
        {
            var data = await dbContext.HotelUtilities.FindAsync(id);
            if (data == null) return null;
            data.Main = !data.Main;
            await dbContext.SaveChangesAsync();
            return data.Main;
        }

        public async Task<bool> Create(int hotelId, int[] utilityId)
        {
            foreach (var item in utilityId)
            {
                var check = await dbContext.HotelUtilities.FirstOrDefaultAsync(x => x.UtilityId == item);
                if (check == null)
                {
                    var data = new HotelUtility
                    {
                        HotelId = hotelId,
                        UtilityId = item,
                        Main = false,
                    };

                    await dbContext.HotelUtilities.AddAsync(data);
                }
            }
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await dbContext.HotelUtilities.FindAsync(id);
            if (data == null) return false;
            dbContext.HotelUtilities.Remove(data);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
