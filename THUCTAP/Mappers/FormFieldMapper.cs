using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class FormFieldMapper
    {
        public static FormField ToFormField(this CustomFieldCreateRequest request)
        {
            return new FormField
            {
                label = request.label,
                field = request.fieldKey,
                entityName = "General",
                type = "text",
                colSpan = 12,
                isDetail = false,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };
        }

      
        public static void UpdateFormField(this FormField field, UpdateFormFieldRequest request)
        {
            field.label = request.label;
            field.field = request.fieldKey;
            field.entityName = request.entityName;
            field.type = request.type;
            field.menuId = request.menuId;
            field.updatedAt = DateTime.UtcNow; 
        }
    }
}