using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IFormFieldRepository
    {
        Task<FormField> CreateFormFieldAsync(CustomFieldCreateRequest request);
    }
}