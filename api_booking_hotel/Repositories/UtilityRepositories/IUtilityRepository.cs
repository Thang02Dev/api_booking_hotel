using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.UtilityRepositories
{
    public interface IUtilityRepository
    {
        Task<List<UtilityViewModel>> GetAll();
        Task<UtilityViewModel> GetById(int id);
        Task<object> Create(SetUtilityViewModel model);
        Task<object> Update(SetUtilityViewModel model, int id);
        Task<UtilityViewModel> Delete(int id);
        Task<UtilityPagin> GetPagin(int current, string? keySearch);
    }
}
