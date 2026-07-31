using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace THUCTAP.Models
{
    [Table("Menus")]
    public class Menu : BaseModel
    {
        [JsonPropertyName("to")]
        public string to { get; set; } = string.Empty;

        [JsonPropertyName("parentId")]
        public int? parentid { get; set; } 

        [JsonIgnore]
        [ForeignKey(nameof(parentid))]
        public Menu? parent { get; set; }

        [JsonPropertyName("children")]
        public ICollection<Menu> children { get; set; } = new List<Menu>();

        [JsonPropertyName("label")]
        public string label { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string icon { get; set; } = string.Empty;

        [JsonPropertyName("actions")]
        public ICollection<AppAction> actions { get; set; } = new List<AppAction>();

        [JsonIgnore]
        public ICollection<Group> groups { get; set; } = new List<Group>();
    }
}