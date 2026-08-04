using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class FormFieldCreateRequest
    {
        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("field_key")]
        public string fieldkey { get; set; } = string.Empty;

        // Các thuộc tính cơ bản để cấu hình field động
        [JsonPropertyName("entity_name")]
        public string entityname { get; set; } = "User"; // Mặc định bảng User

        [JsonPropertyName("type")]
        public string type { get; set; } = "text";
    }
}