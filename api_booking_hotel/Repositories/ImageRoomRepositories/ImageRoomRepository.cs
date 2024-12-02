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

        public async Task<List<string>> Create(ImageRoomViewModel model, IFormFile[] files)
        {

            if (model == null || files == null)
            {
                return null;
            }

            var list = new List<string>();

            // Đường dẫn thư mục gốc để lưu file
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Images", "Rooms");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            foreach (var item in files)
            {
                try
                {
                    // Xử lý vị trí
                    var count = dbcontext.ImageRooms.Count();
                    var maxPosition = 0;
                    if (count > 0)
                    {
                        var images = await dbcontext.ImageRooms.Where(x => x.RoomId == model.RoomId).ToListAsync();
                        maxPosition = images.Count != 0 ? images.Max(x => x.Position) : 0; // Giá trị mặc định là 0 nếu không có bản ghi nào

                    }

                    // Tạo tên file duy nhất (tránh ghi đè)
                    var uniqueFileName = $"{Guid.NewGuid()}_{item.FileName}";
                    var filePath = Path.Combine(uploadFolder, uniqueFileName);

                    // Lưu file vào thư mục
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    // Tạo bản ghi trong CSDL
                    var data = new ImageRoom
                    {
                        Active = true,
                        Position = maxPosition + 1,
                        Description = model.Description,
                        RoomId = model.RoomId,
                        Image = $"/Uploads/Images/Rooms/{uniqueFileName}" // Đường dẫn tương đối
                    };

                    await dbcontext.ImageRooms.AddAsync(data);
                    await dbcontext.SaveChangesAsync();

                    // Thêm đường dẫn vào danh sách trả về
                    list.Add(data.Image);
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi theo cách bạn muốn
                    Console.WriteLine($"Error processing file {item.FileName}: {ex.Message}");
                }
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

        public async Task<ImageRoomPagin> GetPagin(int current, int roomId)
        {
            var result = 15f;

            var count = Math.Ceiling(await dbcontext.ImageRooms.Where(x => x.RoomId == roomId).CountAsync() / result);
            var list = await dbcontext.ImageRooms.Where(x => x.RoomId == roomId).Select(x => new ImageRoomViewModel
            {
                Id = x.Id,
                Active = x.Active,
                Position = x.Position,
                Description = x.Description,
                Image = x.Image,
                RoomId = x.RoomId,
            }).OrderBy(x => x.Position).ToListAsync();
            var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
            return new ImageRoomPagin
            {
                Data = data,
                Count = (int)count,
                Current = current
            };
        }

        public async Task<string> Update(ImageRoomViewModel model, int id)
        {
            var data = await dbcontext.ImageRooms.FindAsync(id);
            if (model == null || data == null)
            {
                return null;
            };
            data.Active = true;
            data.Position = model.Position;
            data.Description = model.Description;


            await dbcontext.SaveChangesAsync();

            return data.Image;
        }
    }
}
