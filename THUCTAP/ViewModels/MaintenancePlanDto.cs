using System.Collections.Generic;

namespace THUCTAP.ViewModels
{
    // Cục dữ liệu tổng bao ngoài
    public class MaintenancePlanDto
    {
        public int year { get; set; }
        public string day { get; set; } = string.Empty;
        public string month { get; set; } = string.Empty;
        public string yearNow { get; set; } = string.Empty;
        public List<Dictionary<string, object>> item { get; set; } = new List<Dictionary<string, object>>();
    }

    
}