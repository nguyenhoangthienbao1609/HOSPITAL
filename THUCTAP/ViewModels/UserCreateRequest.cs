using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class UserCreateRequest
    {
        [JsonPropertyName("username")]
        public string username { get; set; } = string.Empty;

        [JsonPropertyName("user_code")]
        public string usercode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string password { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;

        // Frontend sẽ gửi lên một mảng các ID của Group (VD: [1, 2])
        [JsonPropertyName("group_ids")]
        public List<int> groupids { get; set; } = new List<int>();
    }
}