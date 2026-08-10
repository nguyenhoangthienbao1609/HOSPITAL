using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    public class FormFieldCreateRequest : CustomFieldCreateRequest
    {

        [JsonPropertyName("entityName")]
        public string entityName { get; set; } = "User"; 

        [JsonPropertyName("type")]
        public string type { get; set; } = "text";
    }
}