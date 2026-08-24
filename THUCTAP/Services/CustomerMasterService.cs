using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class CustomerMasterService : ICustomerMasterService
    {
        private readonly ICustomerMasterRepository _repository;

        public CustomerMasterService(ICustomerMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<CustomerMasterResponseDto>>GetAllAsync(CustomerMasterFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<CustomerMasterResponseDto>CreateAsync(CustomerMasterRequest request)
        {
            var entity = request.ToCustomerMaster();

            await _repository.CreateAsync(entity);

            return entity.ToCustomerMasterResponse();
        }

        public async Task<CustomerMasterResponseDto?>UpdateAsync(int id, CustomerMasterRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateCustomerMaster(request);

            await _repository.UpdateAsync(entity);

            return entity.ToCustomerMasterResponse();
        }

        public async Task<bool>DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}