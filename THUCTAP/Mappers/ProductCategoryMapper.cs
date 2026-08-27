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
                equipmentCode = request.equipmentCode,
                equipmentName = request.equipmentName,
                model = request.model,
                manufacturer = request.manufacturer,
                countryOfOrigin = request.countryOfOrigin,
                supplierId = request.supplierId,

                serialNumber = request.serialNumber,
                location = request.location,
                receivedDate = request.receivedDate,
                conditionWhenReceived = request.conditionWhenReceived,
                startDateOfUse = request.startDateOfUse,
                conditionWhenStarted = request.conditionWhenStarted
            };
        }

        public static void UpdateProductCategory(this ProductCategory entity, ProductCategoryRequest request)
        {
            entity.equipmentCode = request.equipmentCode;
            entity.equipmentName = request.equipmentName;
            entity.model = request.model;
            entity.manufacturer = request.manufacturer;
            entity.countryOfOrigin = request.countryOfOrigin;
            entity.supplierId = request.supplierId;

            entity.serialNumber = request.serialNumber;
            entity.location = request.location;
            entity.receivedDate = request.receivedDate;
            entity.conditionWhenReceived = request.conditionWhenReceived;
            entity.startDateOfUse = request.startDateOfUse;
            entity.conditionWhenStarted = request.conditionWhenStarted;
        }

        public static ProductCategoryResponseDto ToProductCategoryResponse(this ProductCategory entity)
        {
            return new ProductCategoryResponseDto
            {
                id = entity.id,
                equipmentCode = entity.equipmentCode,
                equipmentName = entity.equipmentName,
                model = entity.model,
                manufacturer = entity.manufacturer,
                countryOfOrigin = entity.countryOfOrigin,
                supplierId = entity.supplierId,
                supplierName = entity.supplier?.supplierName ?? string.Empty,

                serialNumber = entity.serialNumber,
                location = entity.location,
                receivedDate = entity.receivedDate,
                conditionWhenReceived = entity.conditionWhenReceived,
                startDateOfUse = entity.startDateOfUse,
                conditionWhenStarted = entity.conditionWhenStarted
            };
        }
    }
}