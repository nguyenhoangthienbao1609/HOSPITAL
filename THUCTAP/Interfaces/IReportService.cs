namespace THUCTAP.Interfaces
{
    public interface IReportService
    {
        // Hàm  sẽ trả về file PDF dưới dạng mảng byte (byte[])
        Task<byte[]> GenerateUserReportAsync();
    }
}