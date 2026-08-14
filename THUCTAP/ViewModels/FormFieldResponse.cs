using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using THUCTAP.Models;

namespace THUCTAP.ViewModels
{
    public class FormFieldResponse
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("label")]
        public string label { get; set; }

        [JsonPropertyName("fieldKey")]
        public string fieldKey { get; set; }

        [JsonPropertyName("entityName")]
        public string entityName { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("menuId")]
        public int menuId { get; set; }

        [JsonPropertyName("menuName")]
        public string menuName { get; set; }
        


    }
}