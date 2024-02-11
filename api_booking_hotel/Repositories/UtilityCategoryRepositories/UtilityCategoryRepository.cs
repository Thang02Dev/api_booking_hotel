using api_booking_hotel.Commons;
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.UtilityCategoryRepositories
{
    public class UtilityCategoryRepository : IUtilityCategoryRepository
    {
        private readonly MyDbContext dbcontext;

        public UtilityCategoryRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }

        public async Task<UtilityCategoryViewModel> Create(UtilityCategoryViewModel model)
        {
            var isName = await dbcontext.UtilityCategories.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (isName != null) return null;
            var data = new UtilityCategory
            {
                Name = model.Name,
                Slug = ConvertDatas.ConvertToSlug(model.Name),
            };
            await dbcontext.UtilityCategories.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<UtilityCategoryViewModel> Delete(int id)
        {
            var data = await dbcontext.UtilityCategories.FindAsync(id);
            if (data == null) return null;
            dbcontext.UtilityCategories.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new UtilityCategoryViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Slug = data.Slug,
            };
        }

        public async Task<List<UtilityCategoryViewModel>> GetAll()
        {
            var list = await dbcontext.UtilityCategories.Select(x => new UtilityCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
            }).OrderByDescending(x => x.Id).ToListAsync();
            return list;
        }

        public async Task<UtilityCategoryViewModel> GetById(int id)
        {
            var data = await dbcontext.UtilityCategories.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var rs = new UtilityCategoryViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Slug = data.Slug,
            };
            return rs;
        }

        public async Task<UtilityCategoryViewModel> Update(UtilityCategoryViewModel model, int id)
        {
            var data = await dbcontext.UtilityCategories.FindAsync(id);
            if (data == null) return null;
            data.Name = model.Name;
            data.Slug = ConvertDatas.ConvertToSlug(data.Name);
            await dbcontext.SaveChangesAsync();

            return model;
        }
    }
}
