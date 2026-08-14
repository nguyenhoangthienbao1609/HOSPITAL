using System.Threading.Tasks;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class CustomerCategoryService : ICustomerCategoryService
    {
        private readonly ICustomerCategoryRepository _repository;

        // Tiêm trực tiếp Repository
        public CustomerCategoryService(ICustomerCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<CustomerCategoryResponseDto>> GetAllAsync(CustomerCategoryFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<CustomerCategoryResponseDto> CreateAsync(CustomerCategoryRequest request)
        {
            var entity = request.ToCustomerCategory();

            // Gọi Repository và lưu luôn
            await _repository.CreateAsync(entity);

            return entity.ToCustomerCategoryResponse();
        }

        public async Task<CustomerCategoryResponseDto?> UpdateAsync(int id, CustomerCategoryRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateCustomerCategory(request);

            // Gọi Repository và lưu luôn
            await _repository.UpdateAsync(entity);

            return entity.ToCustomerCategoryResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            // Gọi Repository và lưu luôn
            await _repository.DeleteAsync(entity);

            return true;
        }
    }
}