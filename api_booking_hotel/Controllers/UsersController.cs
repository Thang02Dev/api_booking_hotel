using api_booking_hotel.Repositories.UserRepositories;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var rs = await repository.GetAll();
            if (rs == null) return BadRequest();
            return Ok(rs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var rs = await repository.GetById(id);
            if (rs == null) return BadRequest();
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Create(model);
                if (rs == null) return BadRequest("Tạo mới thất bại. Có thể email đã tồn tại!");
                return Ok(new
                {
                    mess = "Thêm mới thành công!",
                    data = rs,
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserViewModel model, int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Update(model, id);
                if (rs == null) return BadRequest("Cập nhật thất bại. Có thể không tìm thấy người dùng!");
                return Ok(new
                {
                    mess = "Cập nhật thành công!",
                    data = rs,
                });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Delete(id);
                if (rs == null) return BadRequest("Xóa thất bại. Có thể không tìm thấy người dung!");
                return Ok(new
                {
                    mess = "Xóa thành công!",
                    data = rs,
                });
            }
        }

        [HttpPost("changed-active/{id:int}")]
        public async Task<IActionResult> ChangedActive(int id)
        {
            var rs = await repository.ChangedActive(id);
            if (rs == null) return BadRequest("Lỗi. Có thể không tìm thấy người dùng!");
            return Ok(new 
            {
                mess = "Thay đổi thành công!",
                before = !rs,
                after = rs,
            });

        }

        [HttpGet("/page/{page:int}")]
        public async Task<IActionResult> GetPagin(int page, string? key)
        {
            var rs = await repository.GetPagin(page, key);
            if (rs == null) return BadRequest();
            return Ok(new
            {
                data = rs.UserViewModels,
                count = rs.Count,
                current = rs.Current,
            });
        }
    }
}
