using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniSoftware;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

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

        public async Task<byte[]> GetTemplateBytesAsync(string? base64Template, string templateName)
        {
            if (!string.IsNullOrWhiteSpace(base64Template))
            {
                var cleanBase64 = base64Template.Contains(",") ? base64Template.Split(',')[1] : base64Template;
                return Convert.FromBase64String(cleanBase64);
            }

            if (string.IsNullOrWhiteSpace(templateName))
            {
                throw new Exception("Vui lòng cung cấp chuỗi Base64 hoặc tên file mẫu (templateName)!");
            }

            string serverTemplatePath = Path.Combine(_env.ContentRootPath, "Templates", templateName);

            if (!File.Exists(serverTemplatePath))
            {
                throw new Exception($"Không tìm thấy file mẫu '{templateName}' trên máy chủ. Vui lòng kiểm tra lại thư mục Templates!");
            }

            return await File.ReadAllBytesAsync(serverTemplatePath);
        }

        public async Task<string> GenerateReportBase64Async(DynamicReportRequest request)
        {
            var reportData = await GetDynamicReportAsync(request);

            if (reportData == null || reportData.Count == 0)
            {
                throw new Exception("Không tìm thấy dữ liệu để xuất báo cáo!");
            }
            var dataToFill = reportData.FirstOrDefault();

            byte[] templateBytes = await GetTemplateBytesAsync(request.base64Template, request.templateName);

            using (var outputStream = new MemoryStream())
            {
                MiniWord.SaveAsByTemplate(outputStream, templateBytes, dataToFill);

                return Convert.ToBase64String(outputStream.ToArray());
            }
        }
        public async Task<MaintenancePlanDto> GetYearlyPlanDataAsync(int year)
        {
            var categories = await _context.ProductCategories
                .Where(x => x.isActive == true)
                .OrderBy(x => x.equipmentName)
                .ToListAsync();

            var reportData = new MaintenancePlanDto
            {
                year = year,
                day = DateTime.Now.Day.ToString("D2"),
                month = DateTime.Now.Month.ToString("D2"),
                yearNow = DateTime.Now.Year.ToString(),
                item = new List<Dictionary<string, object>>()
            };

            int index = 1;
            foreach (var cat in categories)
            {
                var item = new Dictionary<string, object>
                {
                    { "stt", index++ },
                    { "equipmentName", cat.equipmentName ?? "" },
                    { "equipmentCode", cat.equipmentCode ?? "" },
                    { "location", cat.location ?? "" },
                    { "task", "Bảo trì, bảo dưỡng định kỳ" },
                    { "note", "" }
                };

                for (int i = 1; i <= 12; i++)
                {
                    item.Add($"m{i}", "");
                }

                item["m3"] = "X";
                item["m6"] = "X";
                item["m9"] = "X";
                item["m12"] = "X";

                reportData.item.Add(item);
            }

            return reportData;
        }
    }
}