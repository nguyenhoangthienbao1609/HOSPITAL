using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace THUCTAP.Models
{
    [Table("Users")]
    [Index(nameof(usercode), IsUnique = true)]
    public class User : BaseModel
    {
        [JsonPropertyName("username")]
        public string username { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("user_code")]
        public string usercode { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string password { get; set; } = string.Empty;

        [JsonPropertyName("department")]
        public string department { get; set; } = string.Empty;

        // Quan hệ Nhiều-Nhiều: 1 User có nhiều Group
        [JsonIgnore]
        public ICollection<Group> groups { get; set; } = new List<Group>();
    }
}