using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.FeatureRepositories
{
    public interface IFeatureRepository
    {
        Task<List<FeatureViewModel>> GetAll();
        Task<FeatureViewModel> GetById(int id);
        Task<object> Create(FeatureViewModel model);
        Task<object> Update(FeatureViewModel model, int id);
        Task<FeatureViewModel> Delete(int id);
        Task<FeaturePagin> GetPagin(int current, string? keySearch);
    }
}
