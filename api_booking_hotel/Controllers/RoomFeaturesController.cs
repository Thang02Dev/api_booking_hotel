using api_booking_hotel.Repositories.RoomFeatureRepositories;
using Microsoft.AspNetCore.Mvc;

namespace api_booking_hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomFeaturesController : ControllerBase
    {
        private readonly IRoomFeatureRepository repository;

        public RoomFeaturesController(IRoomFeatureRepository _repository)
        {
            repository = _repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int roomId, [FromForm] int[] featureId)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var rs = await repository.Create(roomId, featureId);
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
