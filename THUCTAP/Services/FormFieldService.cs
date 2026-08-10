using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class FormFieldService : IFormFieldService
    {
        private readonly IFormFieldRepository _formFieldRepository;

        public FormFieldService(IFormFieldRepository formFieldRepository)
        {
            _formFieldRepository = formFieldRepository;
        }

        public async Task<FormField> CreateFormFieldAsync(CustomFieldCreateRequest request)
        {
            // 1. Kiểm tra Business Logic (Rule)
            var exists = await _formFieldRepository.FieldKeyExistsAsync(request.fieldKey);
            if (exists)
            {
                throw new Exception($"Field Key '{request.fieldKey}' đã tồn tại trong hệ thống.");
            }

            // 2. Map dữ liệu
            var newField = request.ToFormField();

            // 3. Ra lệnh lưu Data
            await _formFieldRepository.CreateFormFieldAsync(newField);

            return newField;
        }

        public async Task<FormField> UpdateFormFieldAsync(int id, UpdateFormFieldRequest request)
        {
            // 1. Kiểm tra tồn tại
            var field = await _formFieldRepository.GetFormFieldByIdAsync(id);
            if (field == null) return null;

            // 2. Cập nhật dữ liệu thông qua Mapper
            field.UpdateFormField(request);

            // 3. Ra lệnh lưu
            await _formFieldRepository.UpdateFormFieldAsync(field);
            return field;
        }

        public async Task<bool> DeleteFormFieldAsync(int id)
        {
            var field = await _formFieldRepository.GetFormFieldByIdAsync(id);
            if (field == null) return false;

            await _formFieldRepository.DeleteFormFieldAsync(field);
            return true;
        }

        public async Task<List<FormField>> GetAllFieldsAsync(FormFieldFilterRequest filter)
        {
            return await _formFieldRepository.GetAllFieldsFilteredAsync(filter);
        }
    }
}