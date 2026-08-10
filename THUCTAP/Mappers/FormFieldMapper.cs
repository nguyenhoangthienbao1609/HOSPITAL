using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class FormFieldMapper
    {
        // Map từ Request tạo mới sang Entity FormField
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

        // Map cập nhật dữ liệu vào Entity có sẵn
        public static void UpdateFormField(this FormField field, UpdateFormFieldRequest request)
        {
            field.label = request.label;
            field.field = request.fieldKey;
            field.entityName = request.entityName;
            field.type = request.type;
            field.menuId = request.menuId;
            field.updatedAt = DateTime.UtcNow; // Nếu bạn muốn cập nhật thời gian sửa
        }
    }
}