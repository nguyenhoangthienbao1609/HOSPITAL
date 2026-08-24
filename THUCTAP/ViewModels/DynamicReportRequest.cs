namespace THUCTAP.ViewModels
{
    public class DynamicReportRequest
    {
        public string tableName { get; set; } = string.Empty;
        public string selectColumns { get; set; } = "*";
        public string? whereCondition { get; set; }

        public string exportType { get; set; } = "json";

        public IFormFile? templateFile { get; set; }
    }
}