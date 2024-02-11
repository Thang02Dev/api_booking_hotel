using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.HotelRepositories
{
    public interface IHotelRepository
    {
        Task<List<HotelViewModel>> GetAll();
        Task<HotelViewModel> GetById(int id);
        Task<SetHotelViewModel> Create(SetHotelViewModel model);
        Task<SetHotelViewModel> Update(SetHotelViewModel model, int id);
        Task<HotelViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<HotelPagin> GetPagin(int current, string? keySearch);
    }
}
