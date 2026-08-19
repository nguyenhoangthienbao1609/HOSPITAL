using Microsoft.AspNetCore.Mvc;
using THUCTAP.Interfaces;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("users-pdf")]
        public async Task<IActionResult> DownloadUserReport()
        {
            try
            {
                var pdfBytes = await _reportService.GenerateUserReportAsync();

                return File(pdfBytes, "application/pdf", "DanhSachNguoiDung.pdf");
            }
            catch (Exception ex)
            {
                var realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return BadRequest(new { message = "Lỗi xuất báo cáo: " + ex.Message });
            }
        }
    }
}