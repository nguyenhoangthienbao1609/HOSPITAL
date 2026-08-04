using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class UserResponseDto
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; } = string.Empty;

        [JsonPropertyName("user_code")]
        public string usercode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;

        [JsonPropertyName("groups")]
        public List<string> groups { get; set; } = new List<string>();

        [JsonPropertyName("permissions")]
        public List<string> permissions { get; set; } = new List<string>();
    }
}