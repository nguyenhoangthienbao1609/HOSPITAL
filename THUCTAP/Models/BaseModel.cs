using System.ComponentModel.DataAnnotations;

namespace THUCTAP.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int id { get; set; }
        public DateTime createdat { get; set; } = DateTime.UtcNow;
        public DateTime updatedat { get; set; } = DateTime.UtcNow;
    }
}