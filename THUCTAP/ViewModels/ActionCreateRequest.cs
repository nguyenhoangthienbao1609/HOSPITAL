using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class ActionCreateRequest
    {
        [JsonPropertyName("action_name")]
        public string ActionName { get; set; } = string.Empty;

        [JsonPropertyName("action_code")]
        public string ActionCode { get; set; } = string.Empty;
    }
}