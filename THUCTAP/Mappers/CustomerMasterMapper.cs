using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class CustomerMasterMapper
    {
        public static CustomerMaster ToCustomerMaster(this CustomerMasterRequest request)
        {
            return new CustomerMaster
            {
                customerName = request.customerName,
                categoryId = request.categoryId
            };
        }

        public static void UpdateCustomerMaster(this CustomerMaster entity, CustomerMasterRequest request)
        {
            entity.customerName = request.customerName;
            entity.categoryId = request.categoryId;
        }

        public static CustomerMasterResponseDto ToCustomerMasterResponse(this CustomerMaster entity)
        {
            return new CustomerMasterResponseDto
            {
                id = entity.id,
                customerName = entity.customerName,
                categoryId = entity.categoryId,
                categoryName = entity.Category?.groupName
            };
        }
    }
}