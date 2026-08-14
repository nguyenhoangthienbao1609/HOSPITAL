using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IFormFieldService
    {
        Task<FormField> CreateFormFieldAsync(CustomFieldCreateRequest request);
        Task<FormField> UpdateFormFieldAsync(int id, UpdateFormFieldRequest request);
        Task<bool> DeleteFormFieldAsync(int id);
        Task<PagedResult<FormFieldResponse>> GetAllFieldsAsync(FormFieldFilterRequest filter);

    }
}