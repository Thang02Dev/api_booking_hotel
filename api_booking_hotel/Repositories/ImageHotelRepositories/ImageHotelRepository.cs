using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace api_booking_hotel.Repositories.ImageHotelRepositories
{
    public class ImageHotelRepository : IImageHotelRepository
    {
        private readonly MyDbContext dbcontext;

        public ImageHotelRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
            
        }

        public async Task<bool?> ChangedActive(int id)
        {
            var data = await dbcontext.ImageHotels.FindAsync(id);
            if (data == null) return null;
            data.Active = !data.Active;
            await dbcontext.SaveChangesAsync();
            return data.Active;
        }

        public async Task<List<string>> Create(ImageHotelViewModel model, IFormFile[] fileimage)
        {
            if (model == null || fileimage == null || fileimage.Length == 0)
            {
                return null;
            }

            var list = new List<string>();
            foreach (var item in fileimage)
            {
                var data = new ImageHotel
                {
                    Active = true,
                    Position = model.Position,
                    Description = model.Description,
                };
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images/Hotels", item.FileName);
                using (var stream = File.Create(path))
                {
                    await item.CopyToAsync(stream);
                }

                data.Image = "/Uploads/Images/Hotels/" + item.FileName;

                await dbcontext.ImageHotels.AddAsync(data);
                await dbcontext.SaveChangesAsync();

                list.Add(data.Image);
                model.Position+=1;
                
            }
            
            return list;
        }

        public async Task<ImageHotelViewModel> Delete(int id)
        {

            var data = await dbcontext.ImageHotels.FindAsync(id);
            if (data == null) return null;

            if (data.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images/Hotels");
                var imageFileName = Path.GetFileName(data.Image);
                var imagePathToDelete = Path.Combine(uploadsFolder, imageFileName);

                // Kiểm tra xem tệp tồn tại trước khi xóa
                if (File.Exists(imagePathToDelete))
                {
                    File.Delete(imagePathToDelete);
                }
            };

            dbcontext.ImageHotels.Remove(data);
            await dbcontext.SaveChangesAsync();
            
            return new ImageHotelViewModel
            {
                Id = data.Id,
                Image = data.Image,
            };
        }

        public async Task<List<ImageHotelViewModel>> GetAll()
        {
            var list = await dbcontext.ImageHotels.Select(x => new ImageHotelViewModel
            {
                Id = x.Id,
                Active = x.Active,
                Position = x.Position,
                Description = x.Description,
                Image = x.Image,
            }).OrderBy(x => x.Position).ToListAsync();
            return list;
        }

        public async Task<ImageHotelViewModel> GetById(int id)
        {
            var data = await dbcontext.ImageHotels.SingleAsync(x => x.Id == id);
            var cate = new ImageHotelViewModel
            {
                Id = data.Id,
                Position = data.Position,
                Active = data.Active,
                Image =data.Image,
                Description = data.Description,
            };
            return cate;
        }

        public async Task<ImageHotelPagin> GetPagin(int current)
        {
            var result = 15f;
            
            var count = Math.Ceiling(await dbcontext.ImageHotels.CountAsync() / result);
            var list = await GetAll();
            var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
            return new ImageHotelPagin
            {
                Data = data,
                Count = (int)count,
                Current = current
            };
            
        }

        public async Task<string> Update(ImageHotelViewModel model, int id, IFormFile fileimage)
        {
            var data = await dbcontext.ImageHotels.FindAsync(id);
            if (model == null || fileimage == null || fileimage.Length == 0 || data == null)
            {
                return null;
            };
            data.Active = true;
            data.Position = model.Position;
            data.Description = model.Description;

            if (data.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images/Hotels");
                var imageFileName = Path.GetFileName(data.Image);
                var imagePathToDelete = Path.Combine(uploadsFolder, imageFileName);

                // Kiểm tra xem tệp tồn tại trước khi xóa
                if (File.Exists(imagePathToDelete))
                {
                    File.Delete(imagePathToDelete);
                }
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images", "Hotels", fileimage.FileName);
            using (var stream = File.Create(path))
            {
                await fileimage.CopyToAsync(stream);
            }

            data.Image = "/Uploads/Images/Hotels/" + fileimage.FileName;

            await dbcontext.SaveChangesAsync();

            return data.Image;
        }
    }
}
