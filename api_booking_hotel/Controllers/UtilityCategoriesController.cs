﻿using api_booking_hotel.Repositories.UtilityCategoryRepositories;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityCategoriesController : ControllerBase
    {
        private readonly IUtilityCategoryRepository repository;

        public UtilityCategoriesController(IUtilityCategoryRepository _repository)
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
        public async Task<IActionResult> Create(UtilityCategoryViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                try
                {
                    dynamic rs = await repository.Create(model);
                    if (rs.error == 1) return Ok(new
                    {
                        rs.mess,
                        rs.error,
                    });
                    return Ok(new
                    {
                        rs.mess,
                        rs.error,
                        data = rs.model,
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(UtilityCategoryViewModel model, int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                try
                {
                    dynamic rs = await repository.Update(model, id);
                    if (rs == null) return BadRequest("Cập nhật thất bại. Có thể danh mục không tồn tại!");
                    else
                    {
                        if (rs.error == 1) return Ok(new
                        {
                            rs.mess,
                            rs.error,
                        });
                        return Ok(new
                        {
                            rs.mess,
                            rs.error,
                            data = rs.model,
                        });
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Delete(id);
                if (rs == null) return BadRequest("Xóa thất bại. Có thể không tồn tại!");
                return Ok(new
                {
                    mess = "Xóa thành công!",
                    data = rs,
                });
            }
        }
    }
}
