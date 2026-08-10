using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class MenuResponseDto
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("to")]
        public string to { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string icon { get; set; } = string.Empty;

        [JsonPropertyName("children")]
        public List<MenuResponseDto> children { get; set; } = new List<MenuResponseDto>();
       
        [JsonPropertyName("action")]
        public List<string> action { get; set; } = new List<string>();
    }
}