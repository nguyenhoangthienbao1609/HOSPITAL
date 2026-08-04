namespace THUCTAP.ViewModels
{
    public class LoginResponse
    {
        public string token { get; set; } = string.Empty;
        public int userid { get; set; }
        // Sau này nếu cần trả thêm Username hay Role thì thêm vào đây
    }
}