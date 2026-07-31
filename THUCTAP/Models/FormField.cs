using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace THUCTAP.Models
{
    [Table("FormFields")]
    public class FormField : BaseModel
    {
        [JsonPropertyName("entity_name")]
        public string entityname { get; set; } = string.Empty;

        [JsonPropertyName("field")]
        public string field { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string type { get; set; } = string.Empty;

        [JsonPropertyName("col_span")]
        public int colspan { get; set; }

        [JsonPropertyName("options")]
        public string options { get; set; } = string.Empty;

        [JsonPropertyName("tab_name")]
        public string tabname { get; set; } = string.Empty;

        [JsonPropertyName("is_detail")]
        public bool isdetail { get; set; }

        [JsonPropertyName("sort_order")]
        public int sortorder { get; set; }

        [JsonPropertyName("option_label")]
        public string? optionlabel { get; set; }

        [JsonPropertyName("option_value")]
        public string? optionvalue { get; set; }

        [JsonPropertyName("sub_field")]
        public string subfield { get; set; } = string.Empty;

        [JsonPropertyName("tag_field")]
        public string tagfield { get; set; } = string.Empty;
    }
}