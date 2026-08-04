using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class GroupCreateRequest
    {
        [JsonPropertyName("group_name")]
        public string groupname { get; set; } = string.Empty;

        [JsonPropertyName("group_code")]
        public string groupcode { get; set; } = string.Empty;

        
    }
}