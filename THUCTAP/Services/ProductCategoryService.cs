using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ProductCategoryResponseDto>> GetAllAsync(ProductCategoryFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<ProductCategoryResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return entity.ToProductCategoryResponse();
        }

        public async Task<ProductCategoryResponseDto> CreateAsync(ProductCategoryRequest request)
        {
            var entity = request.ToProductCategory();

            // Chỉ gọi Repository, không cần SaveAsync nữa
            await _repository.CreateAsync(entity);

            return entity.ToProductCategoryResponse();
        }

        public async Task<ProductCategoryResponseDto?> UpdateAsync(int id, ProductCategoryRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateProductCategory(request);

            await _repository.UpdateAsync(entity);

            return entity.ToProductCategoryResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}