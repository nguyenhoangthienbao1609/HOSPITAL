using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IReportService
    {
        Task<List<Dictionary<string, object>>> GetDynamicReportAsync(DynamicReportRequest request);
        Task<byte[]> GenerateReportFromUploadedFileAsync(DynamicReportRequest request);
    }
}