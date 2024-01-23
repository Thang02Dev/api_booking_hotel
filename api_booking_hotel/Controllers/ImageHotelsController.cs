using api_booking_hotel.Repositories.ImageHotelRepositories;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageHotelsController : ControllerBase
    {
        private readonly IImageHotelRepository repository;

        public ImageHotelsController(IImageHotelRepository _repository)
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
        public async Task<IActionResult> Create([FromForm]ImageHotelViewModel model, IFormFile[] fileimage)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Create(model, fileimage);
                if (rs == null) return BadRequest("Tạo mới thất bại. Lỗi!");
                return Ok(new
                {
                    mess = "Thêm mới thành công!",
                    data = rs,
                });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromForm]ImageHotelViewModel model, int id, IFormFile fileimage)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Update(model, id, fileimage);
                if (rs == null) return BadRequest("Cập nhật thất bại. Có thể ảnh không tồn tại!");
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
                if (rs == null) return BadRequest("Xóa thất bại. Có thể ảnh không tồn tại!");
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
            if (rs == null) return BadRequest("Lỗi. Có thể ảnh không tồn tại!");
            return Ok(new
            {
                mess = "Thay đổi thành công!",
                before = !rs,
                after = rs,
            });

        }

        [HttpGet("page/{page:int}")]
        public async Task<IActionResult> GetPagin(int page)
        {
            var rs = await repository.GetPagin(page);
            if (rs == null) return BadRequest();
            return Ok(new
            {
                data = rs.Data,
                count = rs.Count,
                current = rs.Current,
            });
        }
    }
}
