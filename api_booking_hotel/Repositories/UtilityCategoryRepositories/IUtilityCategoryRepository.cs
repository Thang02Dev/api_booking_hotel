using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.UtilityCategoryRepositories
{
    public interface IUtilityCategoryRepository
    {
        Task<List<UtilityCategoryViewModel>> GetAll();
        Task<UtilityCategoryViewModel> GetById(int id);
        Task<UtilityCategoryViewModel> Create(UtilityCategoryViewModel model);
        Task<UtilityCategoryViewModel> Update(UtilityCategoryViewModel model, int id);
        Task<UtilityCategoryViewModel> Delete(int id);
    }
}
