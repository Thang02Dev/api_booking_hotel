using api_booking_hotel.DBContext;
using api_booking_hotel.Models;
using api_booking_hotel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_booking_hotel.Repositories.AuthenRepositories
{
    public class AuthenRepository : IAuthenRepository
    {
        private readonly MyDbContext dbcontext;
        private readonly IConfiguration configuration;

        public AuthenRepository(MyDbContext _dbcontext, IConfiguration _configuration) 
        {
            dbcontext = _dbcontext;
            configuration = _configuration;
        } 

        public string GenerateToken(LoginViewModel model, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,model.Email),
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Login(LoginViewModel model, bool role)
        {
            var check = await dbcontext.Users.SingleOrDefaultAsync(x => x.Email.Equals(model.Email) && x.Active == true && x.Role == role);
            if (check == null) return false;
            if (!BCrypt.Net.BCrypt.Verify(model.Password, check.Password)) return false;

            return true;
        }
        public async Task<bool> Register(RegisterViewModel model)
        {
            var isEmail = await dbcontext.Users.SingleOrDefaultAsync(x => x.Email.Equals(model.Email));
            if (isEmail != null) return false;
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
            };
            await dbcontext.Users.AddAsync(user);
            await dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
