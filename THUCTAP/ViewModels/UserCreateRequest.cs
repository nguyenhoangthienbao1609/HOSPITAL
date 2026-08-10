using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class UserCreateRequest
    {
        [JsonPropertyName("userName")]
        public string userName { get; set; } = string.Empty;

        [JsonPropertyName("userCode")]
        public string userCode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string password { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;

   
        [JsonPropertyName("groupId")]
        public List<int> groupId { get; set; } = new List<int>();
    }
}