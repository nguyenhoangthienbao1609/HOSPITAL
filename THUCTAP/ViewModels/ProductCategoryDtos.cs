using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THUCTAP.ViewModels
{
    
    public class ProductCategoryFilterRequest : PagingRequestBase
    {
        public string? categoryName { get; set; }
        public string? categoryCode { get; set; }
    }

  
    public class ProductCategoryRequest
    {
        [JsonPropertyName("categoryName")]
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        public string categoryName { get; set; } = string.Empty;

        [JsonPropertyName("categoryCode")]
        [Required(ErrorMessage = "Mã danh mục không được để trống!")]
        public string categoryCode { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string? description { get; set; }
    }

   
    public class ProductCategoryResponseDto
    {
        public int id { get; set; }
        public string categoryName { get; set; } = string.Empty;
        public string categoryCode { get; set; } = string.Empty;
        public string? description { get; set; }
    }
}