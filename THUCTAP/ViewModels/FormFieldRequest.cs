using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class FormFieldRequest
    {
        [JsonPropertyName("entityName")]
        public string entityName { get; set; }

        [JsonPropertyName("field")]
        [Required(ErrorMessage = "Field không được để trống!")]
        public string field { get; set; }

        [JsonPropertyName("label")]
        
        public string? label { get; set; }

        [JsonPropertyName("type")]
       
        public string? type { get; set; }

        [JsonPropertyName("colSpan")]
        public int colSpan { get; set; }

        [JsonPropertyName("option")]
        public string? option { get; set; }

        [JsonPropertyName("tabName")]
        public string? tabName { get; set; }

        [JsonPropertyName("isDetail")]
        public bool isDetail { get; set; }

        [JsonPropertyName("sortOrder")]
        public int sortOrder { get; set; }

        [JsonPropertyName("optionLabel")]
        public string? optionLabel { get; set; }

        [JsonPropertyName("optionValue")]
        public string? optionValue { get; set; }

        [JsonPropertyName("subField")]
        public string? subField { get; set; }

        [JsonPropertyName("tagField")]
        public string? tagField { get; set; }

        [JsonPropertyName("menuId")]
        [Required(ErrorMessage = "Menu ID không được để trống!")]
        public int menuId { get; set; }
    }
}