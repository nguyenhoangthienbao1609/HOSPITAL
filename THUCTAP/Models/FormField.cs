using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace THUCTAP.Models
{
    [Table("FormFields")]
    public class FormField : BaseModel
    {
        [JsonPropertyName("entityName")]
        public string entityName { get; set; } = string.Empty;

        [JsonPropertyName("field")]
        public string field { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string type { get; set; } = string.Empty;

        [JsonPropertyName("colSpan")]
        public int colSpan { get; set; }

        [JsonPropertyName("option")]
        public string option { get; set; } = string.Empty;

        [JsonPropertyName("tabName")]
        public string tabName { get; set; } = string.Empty;

        [JsonPropertyName("isDetail")]
        public bool isDetail { get; set; }

        [JsonPropertyName("sortOrder")]
        public int sortOrder { get; set; }

        [JsonPropertyName("optionLabel")]
        public string? optionLabel { get; set; }

        [JsonPropertyName("optionValue")]
        public string? optionValue { get; set; }

        [JsonPropertyName("subField")]
        public string subField { get; set; } = string.Empty;

        [JsonPropertyName("tagField")]
        public string tagField { get; set; } = string.Empty;

        [JsonPropertyName("menuId")]
        public int? menuId { get; set; }

        [ForeignKey("menuId")]
        [JsonIgnore] 
        public Menu? Menu { get; set; }
    }
}