using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace THUCTAP.Models
{
    [Table("Groups")]
    [Index(nameof(name), IsUnique = true)]
    [Index(nameof(code), IsUnique = true)]
    public class Group : BaseModel
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public string code { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string description { get; set; } = string.Empty;

        [JsonPropertyName("menus")]
        public ICollection<Menu> menus { get; set; } = new List<Menu>();

        [JsonPropertyName("actions")]
        public ICollection<AppAction> actions { get; set; } = new List<AppAction>();

        [JsonIgnore]
        public ICollection<User> users { get; set; } = new List<User>();
    }
}