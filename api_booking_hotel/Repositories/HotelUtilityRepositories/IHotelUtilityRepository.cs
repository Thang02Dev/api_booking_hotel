using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.HotelUtilityRepositories
{
    public interface IHotelUtilityRepository
    {
        Task<bool> Create(int hotelId, int[] utilityId);
        Task<bool> Delete(int id);
        Task<bool?> ChangedMain(int id);
    }
}
