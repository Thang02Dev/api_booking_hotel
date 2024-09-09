using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.UtilityCategoryRepositories
{
    public interface IUtilityCategoryRepository
    {
        Task<List<UtilityCategoryViewModel>> GetAll();
        Task<UtilityCategoryViewModel> GetById(int id);
        Task<object> Create(UtilityCategoryViewModel model);
        Task<object> Update(UtilityCategoryViewModel model, int id);
        Task<UtilityCategoryViewModel> Delete(int id);
    }
}
