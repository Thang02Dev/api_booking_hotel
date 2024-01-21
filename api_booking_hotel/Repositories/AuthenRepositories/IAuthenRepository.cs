using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.AuthenRepositories
{
    public interface IAuthenRepository
    {
        Task<bool> Login(LoginViewModel model, bool role);
        Task<bool> Register(RegisterViewModel model);
        string GenerateToken(LoginViewModel model, string role);
    }
}
