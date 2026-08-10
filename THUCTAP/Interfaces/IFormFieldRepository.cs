using System.Threading.Tasks;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IFormFieldRepository
    {
        Task<bool> FieldKeyExistsAsync(string fieldKey);
        Task<FormField?> GetFormFieldByIdAsync(int id);
        Task CreateFormFieldAsync(FormField field);
        Task UpdateFormFieldAsync(FormField field);
        Task DeleteFormFieldAsync(FormField field);
        Task<List<FormField>> GetAllFieldsFilteredAsync(FormFieldFilterRequest filter);


    }
}