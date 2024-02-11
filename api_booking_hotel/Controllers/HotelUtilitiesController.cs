using api_booking_hotel.Repositories.HotelUtilityRepositories;
using api_booking_hotel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelUtilitiesController : ControllerBase
    {
        private readonly IHotelUtilityRepository repository;

        public HotelUtilitiesController(IHotelUtilityRepository _repository) {
            repository = _repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int hotelId,[FromForm] int[] utilityId)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Create(hotelId, utilityId);
                if (rs != true) return BadRequest("Tạo mới thất bại!");
                return Ok(new
                {
                    mess = "Thêm mới thành công!",
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
                if (rs == false) return BadRequest("Xóa thất bại. Có thể không tồn tại!");
                return Ok(new
                {
                    mess = "Xóa thành công!",
                    data = rs,
                });
            }
        }
    }
}
