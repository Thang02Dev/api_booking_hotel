using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.ImageHotelRepositories
{
    public interface IImageHotelRepository
    {
        Task<List<ImageHotelViewModel>> GetAll();
        Task<ImageHotelViewModel> GetById(int id);
        Task<List<string>> Create(ImageHotelViewModel model, IFormFile[] fileimage);
        Task<string> Update(int id, ImageHotelViewModel model);
        Task<ImageHotelViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<ImageHotelPagin> GetPagin(int current, int hotelId);
    }
}
