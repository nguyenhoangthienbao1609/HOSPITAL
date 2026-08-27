using Microsoft.AspNetCore.Mvc;
using MiniSoftware;
using THUCTAP.Interfaces;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using THUCTAP.Services;

namespace THUCTAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IMaintenanceLogService _maintenanceLogService; // Thêm Service Nhật ký

        public ReportController(IEquipmentService equipmentService, IMaintenanceLogService maintenanceLogService)
        {
            _equipmentService = equipmentService;
            _maintenanceLogService = maintenanceLogService;
        }

        [HttpPost]
        public async Task<IActionResult> ExportEquipmentProfile(int id, IFormFile templateFile)
        {
            if (templateFile == null || templateFile.Length == 0)
            {
                return BadRequest(new { message = "Vui lòng tải lên file mẫu lylichthietbi.docx!" });
            }

            var extension = Path.GetExtension(templateFile.FileName).ToLower();
            if (extension != ".docx")
            {
                return BadRequest(new { message = "Hệ thống chỉ hỗ trợ file Word định dạng .docx!" });
            }

            var equipmentData = await _equipmentService.GetByIdAsync(id);
            if (equipmentData == null)
            {
                return NotFound(new { message = "Không tìm thấy thông tin thiết bị!" });
            }

            try
            {
                byte[] templateBytes;
                using (var ms = new MemoryStream())
                {
                    await templateFile.CopyToAsync(ms);
                    templateBytes = ms.ToArray();
                }

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, equipmentData);

                    byte[] fileBytes = outputStream.ToArray();
                    string fileName = $"LyLich_{equipmentData.equipmentCode}_{DateTime.Now:yyyyMMddHHmmss}.docx";
                    string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                    return File(fileBytes, contentType, fileName);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }
        [HttpPost("maintenance-log/monthly/export-word")]
        public async Task<IActionResult> ExportMonthlyMaintenanceLog([FromQuery] int equipmentId, [FromQuery] int month, [FromQuery] int year, IFormFile templateFile)
        {
            if (templateFile == null || templateFile.Length == 0)
            {
                return BadRequest(new { message = "Vui lòng tải lên file mẫu NhatKiBaoDuong.docx!" });
            }

            var extension = Path.GetExtension(templateFile.FileName).ToLower();
            if (extension != ".docx")
            {
                return BadRequest(new { message = "Hệ thống chỉ hỗ trợ file Word định dạng .docx!" });
            }

            var report = await _maintenanceLogService.GetMonthlyReportAsync(equipmentId, month, year);
            if (report == null)
            {
                return NotFound(new { message = "Không tìm thấy dữ liệu báo cáo!" });
            }

            try 
            { 
  
                var wordData = new Dictionary<string, object>
                {
                    { "equipmentName", report.equipmentName },
                    { "equipmentCode", report.equipmentCode },
                    { "month", month.ToString("D2") }, 
                    { "year", year.ToString() },
                    { "allInspectors", report.allInspectors },
                    { "allReviewers", report.allReviewers },
                    { "inspectionDate", DateTime.Now.ToString("dd/MM/yyyy") },
                    { "reviewDate", DateTime.Now.ToString("dd/MM/yyyy") }
                };

                for (int i = 1; i <= 31; i++)
                {
                    wordData.Add($"d{i}_daily", "");
                    wordData.Add($"d{i}_weekly", "");
                    wordData.Add($"d{i}_monthly", "");
                    wordData.Add($"d{i}_quarterly", "");
                    wordData.Add($"d{i}_asNeeded", "");
                    wordData.Add($"d{i}_note", "");
                    wordData.Add($"d{i}_exe", "");
                }

                foreach (var log in report.dailyLogs)
                {
                    int day = log.logDate.Day; 

                    wordData[$"d{day}_daily"] = log.isDaily;
                    wordData[$"d{day}_weekly"] = log.isWeekly;
                    wordData[$"d{day}_monthly"] = log.isMonthly;
                    wordData[$"d{day}_quarterly"] = log.isQuarterly;
                    wordData[$"d{day}_asNeeded"] = log.isAsNeeded;
                    wordData[$"d{day}_note"] = log.note;
                    wordData[$"d{day}_exe"] = log.executorName; // Tên nhân viên
                }

                byte[] templateBytes;
                using (var ms = new MemoryStream())
                {
                    await templateFile.CopyToAsync(ms);
                    templateBytes = ms.ToArray();
                }

                using (var outputStream = new MemoryStream())
                {
                    MiniWord.SaveAsByTemplate(outputStream, templateBytes, wordData);

                    byte[] fileBytes = outputStream.ToArray();
                    string fileName = $"NhatKyBaoDuong_{report.equipmentCode}_Thang{month:D2}_{year}.docx";
                    string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                    return File(fileBytes, contentType, fileName);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tạo file Word: " + ex.Message });
            }
        }
    }
}