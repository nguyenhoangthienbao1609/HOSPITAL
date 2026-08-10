using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class GroupCreateRequest
    {
        [JsonPropertyName("groupName")]
        public string? groupName { get; set; } = string.Empty;

        [JsonPropertyName("groupCode")]
        public string? groupCode { get; set; } = string.Empty;

        
    }
}