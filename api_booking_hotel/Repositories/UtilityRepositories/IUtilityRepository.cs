using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.UtilityRepositories
{
    public interface IUtilityRepository
    {
        Task<List<UtilityViewModel>> GetAll();
        Task<UtilityViewModel> GetById(int id);
        Task<SetUtilityViewModel> Create(SetUtilityViewModel model);
        Task<SetUtilityViewModel> Update(SetUtilityViewModel model, int id);
        Task<UtilityViewModel> Delete(int id);
        Task<UtilityPagin> GetPagin(int current, string? keySearch);
    }
}
