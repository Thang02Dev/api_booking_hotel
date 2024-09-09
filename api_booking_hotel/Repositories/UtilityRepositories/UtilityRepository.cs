using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.UtilityRepositories
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly MyDbContext dbcontext;

        public UtilityRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }

        public async Task<object> Create(SetUtilityViewModel model)
        {
            var isName = await dbcontext.Utilities.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (isName != null) return new
            {
                mess = "Tên đã tồn tại!",
                error = 1
            };
            var data = new Utility
            {
                Name = model.Name,
                UtilityCategoryId = model.UtilityCategoryId,
            };
            await dbcontext.Utilities.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return new
            {
                model,
                mess = "Thêm mới thành công!",
                error = 0
            };
        }

        public async Task<UtilityViewModel> Delete(int id)
        {
            var data = await dbcontext.Utilities.FindAsync(id);
            if (data == null) return null;
            dbcontext.Utilities.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new UtilityViewModel
            {
                Id = data.Id,
                Name = data.Name,
                UtilityCategoryId = data.UtilityCategoryId
            };
        }

        public async Task<List<UtilityViewModel>> GetAll()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var list = await dbcontext.Utilities.Select(x => new UtilityViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UtilityCategoryId = x.UtilityCategoryId,
                UtilityCategoryViewModel = new UtilityCategoryViewModel
                {
                    Name = x.UtilityCategory.Name,
                    Slug = x.UtilityCategory.Slug
                } ?? null
            }).OrderByDescending(x => x.Id).ToListAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.


            return list;
        }

        public async Task<UtilityViewModel> GetById(int id)
        {
            var data = await dbcontext.Utilities.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var rs = new UtilityViewModel
            {
                Id = data.Id,
                Name = data.Name,
                UtilityCategoryId = data.UtilityCategoryId,

            };
            return rs;
        }

        public async Task<UtilityPagin> GetPagin(int current, string? keySearch)
        {
            var result = 15f;
            if (keySearch != null && keySearch.Length > 0)
            {
                var list = GetAll().Result.Where(x => x.Name.Contains(keySearch, StringComparison.CurrentCultureIgnoreCase)
                                   ).ToList();
                var count = Math.Ceiling(list.Count / result);

                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new UtilityPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
            else
            {
                var count = Math.Ceiling(await dbcontext.Utilities.CountAsync() / result);
                var list = await GetAll();
                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new UtilityPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
        }

        public async Task<object> Update(SetUtilityViewModel model, int id)
        {
            var data = await dbcontext.Utilities.FindAsync(id);
            if (data == null) return new
            {
                mess = "Thông tin không tồn tại!",
                error = 2
            };
            else
            {
                var isName = await dbcontext.Utilities.SingleOrDefaultAsync(x => x.Name == model.Name);
                if (isName != null && data.Name != model.Name) return new
                {
                    mess = "Tên đã tồn tại!",
                    error = 1
                };
                data.Name = model.Name;
                data.UtilityCategoryId = model.UtilityCategoryId;
                await dbcontext.SaveChangesAsync();

                return new
                {
                    model,
                    mess = "Cập nhật thành công!",
                    error = 0
                };
            }
            
        }
    }
}
