using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class CustomFieldCreateRequest
    {
        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("field_key")]
        public string fieldkey { get; set; } = string.Empty;
    }
}