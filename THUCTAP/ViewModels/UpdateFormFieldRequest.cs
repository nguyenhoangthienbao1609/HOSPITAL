using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class UpdateFormFieldRequest
    {

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("fieldKey")]
        public string fieldKey { get; set; } = string.Empty;

        [JsonPropertyName("entityName")]
        public string entityName { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string type { get; set; } = string.Empty;

        [JsonPropertyName("menuId")]
        public int? menuId { get; set; }
    }
}