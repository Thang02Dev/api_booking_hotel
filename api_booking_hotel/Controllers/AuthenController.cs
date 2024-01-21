using api_booking_hotel.Repositories.AuthenRepositories;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenRepository repository;

        public AuthenController(IAuthenRepository _repository)
        {
            repository = _repository;
        }

        [AllowAnonymous]
        [HttpPost("login/{role}")]
        public async Task<IActionResult> Login(LoginViewModel model, bool role)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            else
            {
                var rs = await repository.Login(model, role);
                if(!rs) return BadRequest("Email hoặc mật khẩu không đúng!");
                string roleName = "Admin";
                if (role == true) roleName = "Customer";
                string token = repository.GenerateToken(model, roleName);
                return Ok(new {
                    mess = "Đăng nhập thành công!",
                    token,
                });
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            else
            {
                var rs = await repository.Register(model);
                if (!rs) return BadRequest("Đăng ký tài khoản thất bại. Email có thể đã tồn tại!");
                return Ok(new
                {
                    mess = "Đăng ký tài khoản thành công!",
                });
            }
        }
    }
}
