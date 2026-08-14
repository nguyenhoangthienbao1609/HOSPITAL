using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategory ToProductCategory(this ProductCategoryRequest request)
        {
            return new ProductCategory
            {
                categoryName = request.categoryName,
                categoryCode = request.categoryCode,
                description = request.description
            };
        }

        public static void UpdateProductCategory(this ProductCategory entity, ProductCategoryRequest request)
        {
            entity.categoryName = request.categoryName;
            entity.categoryCode = request.categoryCode;
            entity.description = request.description;
        }

        public static ProductCategoryResponseDto ToProductCategoryResponse(this ProductCategory entity)
        {
            return new ProductCategoryResponseDto
            {
                id = entity.id,
                categoryName = entity.categoryName,
                categoryCode = entity.categoryCode,
                description = entity.description
            };
        }
    }
}