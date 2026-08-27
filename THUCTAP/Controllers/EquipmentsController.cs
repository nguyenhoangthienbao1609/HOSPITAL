using Microsoft.AspNetCore.Mvc;
using MiniSoftware;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _service;

        public EquipmentsController(IEquipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EquipmentFilterRequest filter)
        {
            var result = await _service.GetAllAsync(filter);
            return Ok(new { message = "Thành công", data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipmentRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(new { message = "Thêm mới thiết bị và các danh sách liên quan thành công!", data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EquipmentRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null) return NotFound(new { message = "Không tìm thấy thiết bị" });
            return Ok(new { message = "Cập nhật thành công!", data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted) return NotFound(new { message = "Không tìm thấy" });
            return Ok(new { message = "Xóa thành công" });
        }
        //[HttpPost("{id}/export-word")]
        //public async Task<IActionResult> ExportEquipmentProfile(int id, IFormFile templateFile)
        //{
        //    if (templateFile == null || templateFile.Length == 0)
        //    {
        //        return BadRequest(new { message = "Vui lòng tải lên file mẫu lylichthietbi.docx!" });
        //    }

        //    var extension = Path.GetExtension(templateFile.FileName).ToLower();
        //    if (extension != ".docx")
        //    {
        //        return BadRequest(new { message = "Hệ thống chỉ hỗ trợ file Word định dạng .docx!" });
        //    }

        //    // Gọi hàm GetByIdAsync mà chúng ta vừa thêm ở Service
        //    var equipmentData = await _service.GetByIdAsync(id);
        //    if (equipmentData == null)
        //    {
        //        return NotFound(new { message = "Không tìm thấy thông tin thiết bị!" });
        //    }

        //    try
        //    {
        //        byte[] templateBytes;
        //        using (var ms = new MemoryStream())
        //        {
        //            await templateFile.CopyToAsync(ms);
        //            templateBytes = ms.ToArray();
        //        }

        //        using (var outputStream = new MemoryStream())
        //        {
        //            // MiniWord lấp đầy dữ liệu vào file
        //            MiniWord.SaveAsByTemplate(outputStream, templateBytes, equipmentData);

        //            byte[] fileBytes = outputStream.ToArray();
        //            string fileName = $"LyLich_{equipmentData.equipmentCode}_{DateTime.Now:yyyyMMddHHmmss}.docx";
        //            string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        //            return File(fileBytes, contentType, fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
        //    }
        //}
    }
}