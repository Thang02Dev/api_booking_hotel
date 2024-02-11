using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace api_booking_hotel.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext dbcontext;

        public UserRepository(MyDbContext _dbcontex)
        {
            dbcontext = _dbcontex;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var list = await dbcontext.Users.Select(x => new UserViewModel { 
                Id = x.Id,
                Email = x.Email,
                Full_Name = x.Full_Name,
                Gender = x.Gender,
                Password = x.Password,
                Phone_Number = x.Phone_Number,
                Role = x.Role,
                City = x.City,
                Active = x.Active,
            }).OrderByDescending(x=>x.Id).ToListAsync();
            return list;
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var data = await dbcontext.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            var user = new UserViewModel
            {
                Id = data.Id,
                Email = data.Email,
                Full_Name = data.Full_Name,
                Gender = data.Gender,
                Password = data.Password,
                Phone_Number = data.Phone_Number,
                Role= data.Role,
                Created_Date =data.Created_Date,
                Updated_Date = data.Updated_Date,
                City = data.City,
                Active = data.Active,
            };
            return user;
        }

        public async Task<UserViewModel> Create(UserViewModel model)
        {
            var isEmail = await dbcontext.Users.SingleOrDefaultAsync(x=>x.Email == model.Email);
            if (isEmail != null) return null;
            var passHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var user = new User
            {
                Email = model.Email,
                Password = passHash,
                Full_Name = model.Full_Name,
                Role = true,
                Active = true,
                Gender = model.Gender,
                Phone_Number = model.Phone_Number,
                Created_Date = DateTime.Now,
                City = model.City,
            };
            await dbcontext.Users.AddAsync(user);
            await dbcontext.SaveChangesAsync();
            return model;
        }

        public async Task<UserViewModel> Update(UserViewModel model, int id)
        {
            var data = await dbcontext.Users.FindAsync(id);
            if (data == null) return null;
            var passHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            data.Full_Name = model.Full_Name;
            data.Password = passHash;
            data.Gender = model.Gender;
            data.City = model.City;
            data.Phone_Number = model.Phone_Number;
            data.Role = model.Role;
            data.Updated_Date = DateTime.Now;
            await dbcontext.SaveChangesAsync();

            return model;
        }

        public async Task<UserViewModel> Delete(int id)
        {
            var data = await dbcontext.Users.FindAsync(id);
            if (data == null) return null;
            dbcontext.Users.Remove(data);
            await dbcontext.SaveChangesAsync();
            return new UserViewModel
            {
                Id = data.Id,
                Full_Name = data.Full_Name,
                Email = data.Email,
            };
        }

        public async Task<bool?> ChangedActive(int id)
        {
            var data = await dbcontext.Users.FindAsync(id);
            if (data == null) return null;
            data.Active = !data.Active;
            await dbcontext.SaveChangesAsync();
            return data.Active;
        }

        public async Task<UserPagin> GetPagin(int current, string? keySearch)
        {
            var result = 15f;     
            if(keySearch != null && keySearch.Length > 0)
            {     
                var list = GetAll().Result.Where(x => x.Full_Name.ToLower().Contains(keySearch.ToLower())
                                    || x.Email.ToLower().Contains(keySearch.ToLower())).ToList();
                var count = Math.Ceiling(list.Count / result);

                var data = list.Skip((current - 1) * (int)result).Take((int)result).ToList();
                return new UserPagin
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
                return new UserPagin
                {
                    Data = data,
                    Count = (int)count,
                    Current = current
                };
            }

        }
    }
}
