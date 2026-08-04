namespace THUCTAP.ViewModels
{
    public class UpdateGroupPermissionRequest
    {
        // Đảm bảo chỉ có 1 dòng MenuIds
        public List<int> MenuIds { get; set; } = new List<int>();

        // Đảm bảo chỉ có 1 dòng ActionIds
        public List<int> ActionIds { get; set; } = new List<int>();
    }
}