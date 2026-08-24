using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;


namespace THUCTAP.Services
{
    public class FormFieldService : IFormFieldService
    {
        private readonly IFormFieldRepository _formFieldRepository;

        // Tiêm trực tiếp Repository
        public FormFieldService(IFormFieldRepository formFieldRepository)
        {
            _formFieldRepository = formFieldRepository;
        }
        
        public async Task<FormField>CreateFormFieldAsync(FormFieldRequest request)
        {
            var newField = new FormField
            {
                label = request.label,
                field = request.field,
                entityName = request.entityName,
                type = request.type,
                colSpan = request.colSpan,
                option = request.option,
                subField = request.subField,
                tagField = request.tagField,
                isSearchAble = request.isSearchAble,
                isShowInForm = request.isShowInForm,
                isShowInList = request.isShowInList,
                tabName = request.tabName,
                endPoint = request.endPoint,
                sortOrder = request.sortOrder,
                menuId = request.menuId
            };


            await _formFieldRepository.CreateFormFieldAsync(newField);
            return newField;
        }

        public async Task<FormField>UpdateFormFieldAsync(int id, FormFieldRequest request)
        {
            var field = await _formFieldRepository.GetFormFieldByIdAsync(id);
            if (field == null) return null;

            field.UpdateFormField(request);

            await _formFieldRepository.UpdateFormFieldAsync(field);
            return field;
        }

        public async Task<bool>DeleteFormFieldAsync(int id)
        {
            var field = await _formFieldRepository.GetFormFieldByIdAsync(id);
            if (field == null) return false;

            await _formFieldRepository.DeleteFormFieldAsync(field);
            return true;
        }

        public async Task<PagedResult<FormFieldResponse>>GetAllFieldsAsync(FormFieldFilterRequest filter)
        {
            return await _formFieldRepository.GetAllFieldsAsync(filter);
        }
    }
}