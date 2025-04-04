﻿using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.RoomRepositories
{
    public interface IRoomRepository
    {
        Task<List<RoomViewModel>> GetAll();
        Task<RoomViewModel> GetById(int id);    
        Task<object> Create(SetRoomViewModel model);
        Task<object> Update(SetRoomViewModel model, int id);
        Task<RoomViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<RoomPagin> GetPagin(int hotelId,int current, string? keySearch);
    }
}
