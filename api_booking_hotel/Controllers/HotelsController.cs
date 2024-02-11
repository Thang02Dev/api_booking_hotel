﻿using api_booking_hotel.Repositories.HotelRepositories;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository repository;

        public HotelsController(IHotelRepository _repository) 
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
            if (rs == null) return BadRequest("Không tìm thấy!");
            return Ok(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SetHotelViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Create(model);
                if (rs == null) return BadRequest("Tạo mới thất bại. Có thể tên đã tồn tại!");
                return Ok(new
                {
                    mess = "Thêm mới thành công!",
                    data = rs,
                });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(SetHotelViewModel model, int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Update(model, id);
                if (rs == null) return BadRequest("Cập nhật thất bại. Có thể khách sạn không tồn tại!");
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
                if (rs == null) return BadRequest("Xóa thất bại. Có thể khách sạn không tồn tại!");
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
            if (rs == null) return BadRequest("Lỗi. Có thể khách sạn không tồn tại!");
            return Ok(new
            {
                mess = "Thay đổi thành công!",
                before = !rs,
                after = rs,
            });

        }

        [HttpGet("page/{page:int}")]
        public async Task<IActionResult> GetPagin(int page, string? key)
        {
            var rs = await repository.GetPagin(page, key);
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
