﻿using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.ImageHotelRepositories
{
    public interface IImageHotelRepository
    {
        Task<List<ImageHotelViewModel>> GetAll();
        Task<ImageHotelViewModel> GetById(int id);
        Task<List<string>> Create(SetImageHotelViewModel model, IFormFile[] fileimage);
        Task<string> Update(SetImageHotelViewModel model, int id, IFormFile fileimage);
        Task<ImageHotelViewModel> Delete(int id);
        Task<bool?> ChangedActive(int id);
        Task<ImageHotelPagin> GetPagin(int current);
    }
}
