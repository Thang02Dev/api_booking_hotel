using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.ImageRoomRepositories
{
    public class ImageRoomRepository : IImageRoomRepository
    {
        private readonly MyDbContext dbcontext;

        public ImageRoomRepository(MyDbContext _dbcontext) 
        {
            dbcontext = _dbcontext;
        }
        public async Task<bool?> ChangedActive(int id)
        {
            var data = await dbcontext.ImageRooms.FindAsync(id);
            if (data == null) return null;
            data.Active = !data.Active;
            await dbcontext.SaveChangesAsync();
            return data.Active;
        }

        public async Task<List<string>> Create(ImageRoomViewModel model, IFormFile[] fileimage)
        {
            if (model == null || fileimage == null || fileimage.Length == 0)
            {
                return null;
            }

            var list = new List<string>();
            foreach (var item in fileimage)
            {
                var data = new ImageRoom
                {
                    Active = true,
                    Position = model.Position,
                    Description = model.Description,
                    RoomId = model.RoomId
                };
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images/Rooms", item.FileName);
                using (var stream = File.Create(path))
                {
                    await item.CopyToAsync(stream);
                }

                data.Image = "/Uploads/Images/Rooms/" + item.FileName;

                await dbcontext.ImageRooms.AddAsync(data);
                await dbcontext.SaveChangesAsync();

                list.Add(data.Image);
                model.Position += 1;

            }

            return list;
        }

        public async Task<ImageRoomViewModel> Delete(int id)
        {
            var data = await dbcontext.ImageRooms.FindAsync(id);
            if (data == null) return null;

            if (data.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images/Rooms");
                var imageFileName = Path.GetFileName(data.Image);
                var imagePathToDelete = Path.Combine(uploadsFolder, imageFileName);

                // Kiểm tra xem tệp tồn tại trước khi xóa
                if (File.Exists(imagePathToDelete))
                {
                    File.Delete(imagePathToDelete);
                }
            };

            dbcontext.ImageRooms.Remove(data);
            await dbcontext.SaveChangesAsync();

            return new ImageRoomViewModel
            {
                Id = data.Id,
                Image = data.Image ?? "",
                
            };
        }

        public async Task<List<ImageRoomViewModel>> GetAll()
        {
            var list = await dbcontext.ImageRooms.Select(x => new ImageRoomViewModel
            {
                Id = x.Id,
                Active = x.Active,
                Position = x.Position,
                Description = x.Description,
                Image = x.Image,
                RoomId = x.RoomId,
            }).OrderBy(x => x.Position).ToListAsync();
            return list;
        }

        public async Task<ImageRoomViewModel> GetById(int id)
        {
            var data = await dbcontext.ImageRooms.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var rs = new ImageRoomViewModel
            {
                Id = data.Id,
                Position = data.Position,
                Active = data.Active,
                Image = data.Image,
                Description = data.Description,
                RoomId = data.RoomId,
            };
            return rs;
        }

        public async Task<ImageRoomPagin> GetPagin(int current)
        {
            var result = 15f;

            var count = Math.Ceiling(await dbcontext.ImageRooms.CountAsync() / result);
            var list = await GetAll();
            var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
            return new ImageRoomPagin
            {
                Data = data,
                Count = (int)count,
                Current = current
            };
        }

        public async Task<string> Update(ImageRoomViewModel model, int id, IFormFile fileimage)
        {
            var data = await dbcontext.ImageRooms.FindAsync(id);
            if (model == null || fileimage == null || fileimage.Length == 0 || data == null)
            {
                return null;
            };
            data.Active = true;
            data.Position = model.Position;
            data.Description = model.Description;
            data.RoomId = model.RoomId;
            if (data.Image != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images/Rooms");
                var imageFileName = Path.GetFileName(data.Image);
                var imagePathToDelete = Path.Combine(uploadsFolder, imageFileName);

                // Kiểm tra xem tệp tồn tại trước khi xóa
                if (File.Exists(imagePathToDelete))
                {
                    File.Delete(imagePathToDelete);
                }
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Images", "Rooms", fileimage.FileName);
            using (var stream = File.Create(path))
            {
                await fileimage.CopyToAsync(stream);
            }

            data.Image = "/Uploads/Images/Rooms/" + fileimage.FileName;

            await dbcontext.SaveChangesAsync();

            return data.Image;
        }
    }
}
