using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class CustomFieldCreateRequest
    {
        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("fieldKey")]
        public string fieldKey { get; set; } = string.Empty;
    }
}