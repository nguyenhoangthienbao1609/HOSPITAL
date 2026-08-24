using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport([FromForm] DynamicReportRequest request)
        {
            try
            {
                if (string.Equals(request.exportType, "json", StringComparison.OrdinalIgnoreCase))
                {
                    var data = await _reportService.GetDynamicReportAsync(request);
                    return Ok(new { Message = "Lấy dữ liệu thành công", Data = data });
                }

                if (string.Equals(request.exportType, "word", StringComparison.OrdinalIgnoreCase))
                {
                    if (request.templateFile == null)
                    {
                        return BadRequest("Bạn chọn xuất Word nhưng lại quên tải file Template lên!");
                    }
                    byte[] fileBytes = await _reportService.GenerateReportFromUploadedFileAsync(request);
                    string fileName = $"BaoCao_TuyChinh_{DateTime.Now:yyyyMMddHHmmss}.docx";
                    string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                    return File(fileBytes, contentType, fileName);
                }

                return BadRequest("Loại xuất báo cáo không hợp lệ!");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Message = "Lỗi hệ thống", Error = ex.Message });
            }
        }
    }
}