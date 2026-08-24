using System.Data;
using Microsoft.EntityFrameworkCore;
using MiniSoftware;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReportService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<List<Dictionary<string, object>>> GetDynamicReportAsync(DynamicReportRequest request)
        {
            var resultList = new List<Dictionary<string, object>>();

            string columns = string.IsNullOrWhiteSpace(request.selectColumns) ? "*" : request.selectColumns;
            string sql = $"SELECT {columns} FROM {request.tableName}";

            if (!string.IsNullOrWhiteSpace(request.whereCondition))
            {
                sql += $" WHERE {request.whereCondition}";
            }

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Add(reader.GetName(i), reader.IsDBNull(i) ? "" : reader.GetValue(i));
                            }
                            resultList.Add(row);
                        }
                    }
                }
            }

            return resultList;
        }
        public async Task<byte[]> GenerateReportFromUploadedFileAsync(DynamicReportRequest request)
        {
            if (request.templateFile == null || request.templateFile.Length == 0)
            {
                throw new Exception("Vui lòng tải lên file Word mẫu (.docx)!");
            }

            var fileName = request.templateFile.FileName.ToLower();
            if (fileName.EndsWith(".doc"))
            {
                throw new Exception("Hệ thống không hỗ trợ định dạng .doc cũ. Vui lòng Save As sang .docx!");
            }
            else if (!fileName.EndsWith(".docx"))
            {
                throw new Exception("Chỉ hỗ trợ file mẫu định dạng .docx!");
            }

            var reportData = await GetDynamicReportAsync(request);

            if (reportData == null || reportData.Count == 0)
            {
                throw new Exception("Không tìm thấy dữ liệu để xuất báo cáo!");
            }
            var dataToFill = reportData.FirstOrDefault();

            byte[] templateBytes;
            using (var ms = new MemoryStream())
            {
                await request.templateFile.CopyToAsync(ms);
                templateBytes = ms.ToArray();
            }

            using (var outputStream = new MemoryStream())
            {
                MiniWord.SaveAsByTemplate(outputStream, templateBytes, dataToFill);
                return outputStream.ToArray();
            }
        }
    }
}