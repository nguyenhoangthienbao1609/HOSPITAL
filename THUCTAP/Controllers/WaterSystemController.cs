using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterSystemController : ControllerBase
    {
        private readonly IWaterSystemService _service;
        public WaterSystemController(IWaterSystemService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] WaterSystemFilterRequest filter)
        {
            try
            {
                var result = await _service.GetAllAsync(filter);
                return Ok(new
                {
                    message = "Lấy danh sách phiếu theo dõi thành công!",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(new { message = "Không tìm thấy phiếu theo dõi!" });

                return Ok(new
                {
                    message = "Lấy chi tiết phiếu theo dõi thành công!",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthlyLog([FromQuery] int equipmentId, [FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var result = await _service.GetMonthlyLogAsync(equipmentId, month, year);
                if (result == null) return Ok(new { message = "Chưa có dữ liệu tháng này", data = (object)null });

                return Ok(new
                {
                    message = "Thành công",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("save-daily")]
        public async Task<IActionResult> SaveDaily([FromBody] SaveDailyLogRequest request)
        {
            try
            {
                var msg = await _service.SaveDailyLogAsync(request);
                return Ok(new
                {
                    message = msg,
                    data = (object)null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/inspect")]
        public async Task<IActionResult> Inspect(int id, [FromBody] ProcessWaterLogRequest request)
        {
            try
            {
                var success = await _service.InspectLogAsync(id, request);
                if (!success) return BadRequest(new { message = "Không tìm thấy phiếu hoặc sai trạng thái duyệt" });

                return Ok(new { message = request.isApproved ? "Đã kiểm tra thành công" : "Đã từ chối kiểm tra" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/review")]
        public async Task<IActionResult> Review(int id, [FromBody] ProcessWaterLogRequest request)
        {
            try
            {
                var success = await _service.ReviewLogAsync(id, request);
                if (!success) return BadRequest(new { message = "Không tìm thấy phiếu hoặc sai trạng thái duyệt" });

                return Ok(new { message = request.isApproved ? "Đã xem xét và hoàn tất phiếu" : "Đã từ chối xem xét" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _service.DeleteLogAsync(id);
                if (!success) return NotFound(new { message = "Không tìm thấy phiếu theo dõi hệ thống lọc nước" });

                return Ok(new { message = "Xóa phiếu thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}