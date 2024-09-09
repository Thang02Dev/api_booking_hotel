using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
        Task<object> Create(CategoryViewModel model);
        Task<object> Update(CategoryViewModel model, int id);
        Task<CategoryViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<CategoryPagin> GetPagin(int current, string? keySearch);
    }
}
