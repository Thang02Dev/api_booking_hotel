using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.HotelRepositories
{
    public interface IHotelRepository
    {
        Task<List<HotelViewModel>> GetAll();
        Task<HotelViewModel> GetById(int id);
        Task<object> Create(SetHotelViewModel model);
        Task<object> Update(SetHotelViewModel model, int id);
        Task<HotelViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<HotelPagin> GetPagin(int current, string? keySearch);
    }
}
