using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerMasterController : ControllerBase
    {
        private readonly ICustomerMasterService _service;

        public CustomerMasterController(ICustomerMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CustomerMasterFilterRequest filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(new { message = "Thành công", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerMasterRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(new { message = "Thêm thành công", data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerMasterRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null) return NotFound(new { message = "Không tìm thấy khách hàng này" });
            return Ok(new { message = "Cập nhật thành công", data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted) return NotFound(new { message = "Không tìm thấy khách hàng này" });
            return Ok(new { message = "Xóa thành công" });
        }
    }
}