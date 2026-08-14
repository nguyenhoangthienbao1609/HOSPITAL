namespace THUCTAP.Models
{
    public class ProductCategory : BaseModel
    {
     
        public string categoryName { get; set; } = string.Empty;
        public string categoryCode { get; set; } = string.Empty;
        public string? description { get; set; }
    }
}