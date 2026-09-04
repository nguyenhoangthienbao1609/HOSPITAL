using THUCTAP.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace THUCTAP.Interfaces
{
    public interface IReportService
    {
        Task<List<Dictionary<string, object>>> GetDynamicReportAsync(DynamicReportRequest request);

        Task<string> GenerateReportBase64Async(DynamicReportRequest request);

        Task<byte[]> GetTemplateBytesAsync(string? base64Template, string templateName);
        Task<MaintenancePlanDto> GetYearlyPlanDataAsync(int year);
    }
}