using api_booking_hotel.Commons;
using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext dbcontext;

        public CategoryRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }

        public async Task<bool?> ChangedActive(int id)
        {
            var data = await dbcontext.Categories.FindAsync(id);
            if (data == null) return null;
            data.Active = !data.Active;
            await dbcontext.SaveChangesAsync();
            return data.Active;
        }

        public async Task<CategoryViewModel> Create(CategoryViewModel model)
        {
            var isName = await dbcontext.Categories.SingleOrDefaultAsync(x => x.Name == model.Name);
            if (isName != null) return null;
            var data = new Category
            {
                Name = model.Name,
                Active = true,
                Icon = model.Icon,
                Position = model.Position,
                Slug = ConvertDatas.ConvertToSlug(model.Slug),
            };
            await dbcontext.Categories.AddAsync(data);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<CategoryViewModel> Delete(int id)
        {
            var data = await dbcontext.Categories.FindAsync(id);
            if (data == null) return null;
            dbcontext.Categories.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new CategoryViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Slug = data.Slug,
            };
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var list = await dbcontext.Categories.Select(x => new CategoryViewModel
            {
               Id = x.Id,
               Name = x.Name,
               Active = x.Active,
               Icon = x.Icon,
               Position = x.Position,
               Slug = x.Slug,
            }).OrderByDescending(x => x.Id).ToListAsync();
            return list;
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            var data = await dbcontext.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var rs = new CategoryViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Icon = data.Icon,
                Position = data.Position,
                Slug = data.Slug,
                Active = data.Active,
            };
            return rs;
        }

        public async Task<CategoryPagin> GetPagin(int current, string? keySearch)
        {
            var result = 15f;
            if (keySearch != null && keySearch.Length > 0)
            {
                var list = GetAll().Result.Where(x => x.Name.Contains(keySearch, StringComparison.CurrentCultureIgnoreCase)
                                    || x.Slug.Contains(keySearch, StringComparison.CurrentCultureIgnoreCase)).ToList();
                var count = Math.Ceiling(list.Count / result);

                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new CategoryPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
            else
            {
                var count = Math.Ceiling(await dbcontext.Users.CountAsync() / result);
                var list = await GetAll();
                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new CategoryPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }
        }

        public async Task<CategoryViewModel> Update(CategoryViewModel model, int id)
        {
            var data = await dbcontext.Categories.FindAsync(id);
            if (data == null) return null;
            data.Name = model.Name;
            data.Icon = model.Icon;
            data.Position = model.Position;
            data.Slug = ConvertDatas.ConvertToSlug(data.Name);
            await dbcontext.SaveChangesAsync();

            return model;
        }
    }
}
