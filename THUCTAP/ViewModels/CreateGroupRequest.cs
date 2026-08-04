namespace THUCTAP.ViewModels
{
    public class CreateGroupRequest
    {
        // Thông tin cơ bản của nhóm
        public string group_name { get; set; }
        public string group_code { get; set; }

        // Danh sách quyền (có thể rỗng nếu lúc tạo chưa muốn cấp quyền ngay)
        public List<int> menuids { get; set; } = new List<int>();
        public List<int> actionids { get; set; } = new List<int>();
    }
}