using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class CustomFieldCreateRequest
    {
        [JsonPropertyName("label")]
        [Required(ErrorMessage = "Label không được để trống!")]
        public string label { get; set; }

        [JsonPropertyName("fieldKey")] 
        [Required(ErrorMessage = "Field Key không được để trống!")]
        public string fieldKey { get; set; }

        [JsonPropertyName("type")]
        [Required(ErrorMessage = "Type không được để trống!")]
        public string type { get; set; } = "text"; 

        [JsonPropertyName("entityName")]
        public string entityName { get; set; }

        [JsonPropertyName("menuId")]
        public int menuId { get; set; }
    }
}