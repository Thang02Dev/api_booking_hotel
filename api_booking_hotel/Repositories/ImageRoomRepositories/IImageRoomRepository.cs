using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.ImageRoomRepositories
{
    public interface IImageRoomRepository
    {
        Task<List<ImageRoomViewModel>> GetAll();
        Task<ImageRoomViewModel> GetById(int id);
        Task<List<string>> Create(ImageRoomViewModel model, IFormFile[] fileimage);
        Task<string> Update(ImageRoomViewModel model, int id, IFormFile fileimage);
        Task<ImageRoomViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<ImageRoomPagin> GetPagin(int current);
    }
}
