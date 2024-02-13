using api_booking_hotel.Commons;
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.FeatureRepositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly MyDbContext dbcontext;

        public FeatureRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }

        public async Task<FeatureViewModel> Create(FeatureViewModel model)
        {
            var isName = await dbcontext.Features.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (isName != null) return null;
            var data = new Feature
            {
                Name = model.Name,
                Icon = model.Icon,
                
            };
            await dbcontext.Features.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<FeatureViewModel> Delete(int id)
        {
            var data = await dbcontext.Features.FindAsync(id);
            if (data == null) return null;
            dbcontext.Features.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new FeatureViewModel
            {
                Id = data.Id,
                Name = data.Name,
            };
        }

        public async Task<List<FeatureViewModel>> GetAll()
        {
            var list = await dbcontext.Features.Select(x => new FeatureViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Icon = x.Icon,
     
            }).OrderByDescending(x => x.Id).ToListAsync();
            return list;
        }

        public async Task<FeatureViewModel> GetById(int id)
        {
            var data = await dbcontext.Features.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var rs = new FeatureViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Icon = data.Icon,
            };
            return rs;
        }

        public async Task<FeaturePagin> GetPagin(int current, string? keySearch)
        {
            var result = 15f;
            if (keySearch != null && keySearch.Length > 0)
            {
                var list = GetAll().Result.Where(x => x.Name.Contains(keySearch, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var count = Math.Ceiling(list.Count / result);

                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new FeaturePagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
            else
            {
                var count = Math.Ceiling(await dbcontext.Features.CountAsync() / result);
                var list = await GetAll();
                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new FeaturePagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
        }

        public async Task<FeatureViewModel> Update(FeatureViewModel model, int id)
        {
            var data = await dbcontext.Features.FindAsync(id);
            if (data == null) return null;
            data.Name = model.Name;
            data.Icon = model.Icon;
            await dbcontext.SaveChangesAsync();

            return model;
        }
    }
}
