using api_booking_hotel.Commons;
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace api_booking_hotel.Repositories.HotelRepositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly MyDbContext dbcontext;

        public HotelRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }
        public async Task<bool?> ChangedActive(int id)
        {
            var data = await dbcontext.Hotels.FindAsync(id);
            if (data == null) return null;
            data.Active = !data.Active;
            await dbcontext.SaveChangesAsync();
            return data.Active;
        }

        public async Task<SetHotelViewModel> Create(SetHotelViewModel model)
        {
            var isName = await dbcontext.Hotels.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (isName != null) return null;
            var data = new Hotel
            {
                Name = model.Name,
                Active = true,
                Slug = ConvertDatas.ConvertToSlug(model.Slug),
                Address = model.Address,
                CategoryId = model.CategoryId,
                CheckIn_Time = model.CheckIn_Time,
                CheckOut_Time = model.CheckOut_Time,
                Favorite = model.Favorite,
                Phone_Number= model.Phone_Number,
                Introduce = model.Introduce,
            };
            await dbcontext.Hotels.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<HotelViewModel> Delete(int id)
        {
            var data = await dbcontext.Hotels.FindAsync(id);
            if (data == null) return null;

            var listImages = await dbcontext.ImageHotels.Where(x=>x.HotelId == data.Id).ToListAsync();
            foreach (var item in listImages)
            {
                var image = await dbcontext.ImageHotels.SingleAsync(x => x.Id == item.Id);
                dbcontext.ImageHotels.Remove(image);
            }

            dbcontext.Hotels.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new HotelViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Slug = data.Slug,
            };
        }

        public async Task<List<HotelViewModel>> GetAll()
        {
            var list = await dbcontext.Hotels.Select(x => new HotelViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Active = x.Active,
                Slug = x.Slug,
                CheckIn_Time = x.CheckIn_Time,
                CheckOut_Time = x.CheckOut_Time,
                Introduce = x.Introduce,
                Address = x.Address,
                Favorite = x.Favorite,
                Phone_Number = x.Phone_Number,
                CategoryId = x.CategoryId,
                CategoryViewModel = new CategoryViewModel
                {
                    Name = x.Category.Name,
                    Slug = x.Category.Slug
                } ?? null,
                ImageHotelViewModels = dbcontext.ImageHotels.Where(k=>k.HotelId == x.Id).Select(k=> new ImageHotelViewModel
                {
                    Id = k.Id,
                    Image = k.Image,
                    Active = k.Active,
                    Position = k.Position,
                }).ToList(),
                HotelUtilityViewModels = dbcontext.HotelUtilities.Where(k=>k.HotelId == x.Id).Select(k=> new HotelUtilityViewModel
                {
                    Id= k.Id,
                    UtilityId = k.UtilityId,
                    UtilityViewModel = new UtilityViewModel
                    {
                        Name = k.Utility.Name,
                    } ?? null,
                }).ToList(),
            }).OrderByDescending(x => x.Id).ToListAsync();
            return list;
        }

        public async Task<HotelViewModel> GetById(int id)
        {
            var data = await dbcontext.Hotels.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var rs = new HotelViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Active = data.Active,
                Slug = data.Slug,
                CheckIn_Time =  data.CheckIn_Time,
                CheckOut_Time = data.CheckOut_Time,
                Introduce = data.Introduce,
                Address = data.Address,
                Favorite = data.Favorite,
                Phone_Number = data.Phone_Number,
                CategoryId = data.CategoryId,
                CategoryViewModel = new CategoryViewModel
                {
                    Name = data.Category.Name,
                    Slug = data.Category.Slug
                } ?? null,
                ImageHotelViewModels = dbcontext.ImageHotels.Where(k => k.HotelId == data.Id).Select(k => new ImageHotelViewModel
                {
                    Id = k.Id,
                    Image = k.Image,
                    Active = k.Active,
                    Position = k.Position,
                }).ToList(),
            };
            return rs;
        }

        public async Task<HotelPagin> GetPagin(int current, string? keySearch)
        {
            var result = 15f;
            if (keySearch != null && keySearch.Length > 0)
            {
                var list = GetAll().Result.Where(x => x.Name.ToLower().Contains(keySearch.ToLower())
                                    || x.Slug.ToLower().Contains(keySearch.ToLower())).ToList();
                var count = Math.Ceiling(list.Count / result);

                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new HotelPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
            else
            {
                var count = Math.Ceiling(await dbcontext.Hotels.CountAsync() / result);
                var list = await GetAll();
                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new HotelPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
        }

        public async Task<SetHotelViewModel> Update(SetHotelViewModel model, int id)
        {
            var data = await dbcontext.Hotels.FindAsync(id);
            if (data == null) return null;
            data.Name = model.Name;
            data.Active = true;
            data.Slug = ConvertDatas.ConvertToSlug(model.Slug);
            data.Address = model.Address;
            data.CategoryId = model.CategoryId;
            data.CheckIn_Time = model.CheckIn_Time;
            data.CheckOut_Time = model.CheckOut_Time;
            data.Favorite = model.Favorite;
            data.Phone_Number = model.Phone_Number;
            data.Introduce = model.Introduce;

            await dbcontext.SaveChangesAsync();

            return model;
        }
    }
}
