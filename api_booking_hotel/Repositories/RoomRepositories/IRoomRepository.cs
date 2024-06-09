using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.RoomRepositories
{
    public interface IRoomRepository
    {
        Task<List<RoomViewModel>> GetAll();
        Task<RoomViewModel> GetById(int id);
        Task<SetRoomViewModel> Create(SetRoomViewModel model);
        Task<SetRoomViewModel> Update(SetRoomViewModel model, int id);
        Task<RoomViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<RoomPagin> GetPagin(int current, string? keySearch);
    }
}
