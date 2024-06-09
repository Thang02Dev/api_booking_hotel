using api_booking_hotel.Commons;
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.RoomRepositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDbContext dbcontext;

        public RoomRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }
        public async Task<bool?> ChangedActive(int id)
        {
            var data = await dbcontext.Rooms.FindAsync(id);
            if (data == null) return null;
            data.Active = !data.Active;
            await dbcontext.SaveChangesAsync();
            return data.Active;
        }

        public async Task<SetRoomViewModel> Create(SetRoomViewModel model)
        {
            var isName = await dbcontext.Rooms.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (isName != null) return null;
            var data = new Room
            {
                Name = model.Name,
                Active = true,
                Slug = ConvertDatas.ConvertToSlug(model.Name),
                Description = model.Description,
                NumberOfBeds = model.NumberOfBeds,
                NumberOfGuests = model.NumberOfGuests,
                Price = model.Price,
                Size = model.Size,
                HotelId = model.HotelId,
                Type = model.Type,
                Amount = model.Amount,
            };
            await dbcontext.Rooms.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<RoomViewModel> Delete(int id)
        {
            var data = await dbcontext.Rooms.FindAsync(id);
            if (data == null) return null;

            var roomFeatures = await dbcontext.RoomFeatures.Where(x=>x.RoomId == id).ToListAsync();
            foreach (var item in roomFeatures)
            {
                dbcontext.RoomFeatures.Remove(item);
            }

            dbcontext.Rooms.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new RoomViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Slug = data.Slug,
            };
        }

        public async Task<List<RoomViewModel>> GetAll()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var list = await dbcontext.Rooms.Select( x => new RoomViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                Slug = x.Slug,
                Description =x.Description,
                HotelId = x.HotelId,
                NumberOfBeds = x.NumberOfBeds,
                NumberOfGuests = x.NumberOfGuests,
                Amount = x.Amount,
                Price = x.Price,
                Size = x.Size,
                Type = x.Type,
                HotelViewModel = new HotelViewModel
                {
                    Name = x.Hotel.Name,
                    Slug = x.Hotel.Slug
                } ?? null,
                ImageRoomViewModels = dbcontext.ImageRooms.Where(k=>k.RoomId == x.Id).Select(k=> new ImageRoomViewModel
                {
                    Id = k.Id,
                    Image = k.Image,
                    Position = k.Position,
                    Active = k.Active,
                }).ToList(),
                RoomFeatureViewModels = dbcontext.RoomFeatures.Where(k=>k.RoomId == x.Id).Select(k=> new RoomFeatureViewModel
                {
                    Id = k.Id,
                    FeatureViewModel = new FeatureViewModel
                    {
                        Id = k.Feature.Id,
                        Name = k.Feature.Name
                    } ?? null
                }).ToList(),
            }).OrderByDescending(x => x.Id).ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return list;
        }

        public async Task<RoomViewModel> GetById(int id)
        {
            var data = await dbcontext.Rooms.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var rs = new RoomViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Active = data.Active,
                Slug = data.Slug,
                Description = data.Description,
                HotelId = data.HotelId,
                NumberOfBeds = data.NumberOfBeds,
                NumberOfGuests = data.NumberOfGuests,
                Amount = data.Amount,
                Price = data.Price,
                Size = data.Size,
                Type = data.Type,
                HotelViewModel = new HotelViewModel
                {
                    Name = data.Hotel.Name,
                    Slug = data.Hotel.Slug
                } ?? null,
                ImageRoomViewModels = dbcontext.ImageRooms.Where(k => k.RoomId == data.Id).Select(k => new ImageRoomViewModel
                {
                    Id = k.Id,
                    Image = k.Image,
                    Position = k.Position,
                    Active = k.Active,
                }).ToList(),
                RoomFeatureViewModels = dbcontext.RoomFeatures.Where(k => k.RoomId == data.Id).Select(k => new RoomFeatureViewModel
                {
                    Id = k.Id,
                    FeatureViewModel = new FeatureViewModel
                    {
                        Id = k.Feature.Id,
                        Name = k.Feature.Name
                    } ?? null
                }).ToList(),
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return rs;
        }

        public async Task<RoomPagin> GetPagin(int current, string? keySearch)
        {
            var result = 15f;
            if (keySearch != null && keySearch.Length > 0)
            {
                var list = GetAll().Result.Where(x => x.Name.Contains(keySearch, StringComparison.CurrentCultureIgnoreCase)
                                    || x.Slug.Contains(keySearch, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var count = Math.Ceiling(list.Count / result);

                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new RoomPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
            else
            {
                var count = Math.Ceiling(await dbcontext.Rooms.CountAsync() / result);
                var list = await GetAll();
                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new RoomPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
        }

        public async Task<SetRoomViewModel> Update(SetRoomViewModel model, int id)
        {
            var data = await dbcontext.Rooms.FindAsync(id);
            if (data == null) return null;
            data.Name = model.Name;
            data.NumberOfBeds = model.NumberOfBeds;
            data.NumberOfGuests = model.NumberOfGuests;
            data.Slug = ConvertDatas.ConvertToSlug(data.Name);
            data.Amount = model.Amount;
            data.Description = model.Description;
            data.Size = model.Size;
            data.Type = model.Type;
            data.Price = model.Price;
            data.HotelId = model.HotelId;

            await dbcontext.SaveChangesAsync();

            return model;
        }
    }
}
