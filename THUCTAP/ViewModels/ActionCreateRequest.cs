using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class ActionCreateRequest
    {
        [JsonPropertyName("actionName")]
        public string actionName { get; set; } = string.Empty;

        [JsonPropertyName("actionCode")]
        public string actionCode { get; set; } = string.Empty;
    }
}