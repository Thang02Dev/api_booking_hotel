using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
        Task<UserViewModel> Create(UserViewModel model);
        Task<UserViewModel> Update(UserViewModel model, int id);
        Task<UserViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<UserPagin> GetPagin(int current, string? keySearch);
    }
}
