using api_booking_hotel.Commons;
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace api_booking_hotel.Repositories.HotelReviewRepositories
{
    public class HotelReviewRepository : IHotelReviewRepository
    {
        private readonly MyDbContext dbcontext;

        public HotelReviewRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }

        public async Task<SetHotelReviewViewModel> Create(SetHotelReviewViewModel model)
        {
            var data = new HotelReview
            {
                HotelId = model.HotelId,
                UserId = model.UserId,
                Comment = model.Comment,
                Date = model.Date,
                Rating = model.Rating,
                
            };
            await dbcontext.HotelReviews.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<HotelReviewViewModel> Delete(int id)
        {
            var data = await dbcontext.HotelReviews.FindAsync(id);
            if (data == null) return null;
            dbcontext.HotelReviews.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new HotelReviewViewModel
            {
                Id = data.Id,
                UserId = data.UserId,
                HotelId = data.HotelId
            };
        }

        public async Task<List<HotelReviewViewModel>> GetAll()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var list = await dbcontext.HotelReviews.Select(x => new HotelReviewViewModel
            {
                Id = x.Id,
                Rating = x.Rating,
                Comment = x.Comment,
                Date = x.Date,
                HotelId = x.HotelId,
                UserId = x.UserId,
                HotelViewModel = new HotelViewModel
                {
                    Id = x.Hotel.Id,
                    Name = x.Hotel.Name,
                } ?? null,
                UserViewModel = new UserViewModel
                {
                    Id = x.User.Id,
                    Full_Name = x.User.Full_Name,
                } ?? null
            }).OrderByDescending(x => x.Id).ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return list;
        }

        public async Task<HotelReviewViewModel> GetById(int id)
        {
            var data = await dbcontext.HotelReviews.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var rs = new HotelReviewViewModel
            {
                Id = data.Id,
                Rating = data.Rating,
                Comment = data.Comment,
                Date = data.Date,
                HotelId = data.HotelId,
                UserId = data.UserId,
                HotelViewModel = new HotelViewModel
                {
                    Id = data.Hotel.Id,
                    Name = data.Hotel.Name,
                } ?? null,
                UserViewModel = new UserViewModel
                {
                    Id = data.User.Id,
                    Full_Name = data.User.Full_Name,
                } ?? null
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return rs;
        }

        public async Task<HotelReviewPagin> GetPagin(int current)
        {
            var result = 15f;
            var count = Math.Ceiling(await dbcontext.HotelReviews.CountAsync() / result);
            var list = await GetAll();
            var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
            return new HotelReviewPagin
            {
                Data = data,
                Count = (int)count,
                Current = current
            };
            
        }

        public async Task<SetHotelReviewViewModel> Update(SetHotelReviewViewModel model, int id)
        {
            var data = await dbcontext.HotelReviews.FindAsync(id);
            if (data == null) return null;
            data.Rating = model.Rating;
            data.Comment = model.Comment;
            data.Date = DateTime.Now;
            await dbcontext.SaveChangesAsync();

            return model;
        }
    }
}
