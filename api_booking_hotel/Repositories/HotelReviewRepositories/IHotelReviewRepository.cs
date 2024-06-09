using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.HotelReviewRepositories
{
    public interface IHotelReviewRepository
    {
        Task<List<HotelReviewViewModel>> GetAll();
        Task<HotelReviewViewModel> GetById(int id);
        Task<SetHotelReviewViewModel> Create(SetHotelReviewViewModel model);
        Task<SetHotelReviewViewModel> Update(SetHotelReviewViewModel model, int id);
        Task<HotelReviewViewModel> Delete(int id);
        Task<HotelReviewPagin> GetPagin(int current);
    }
}
