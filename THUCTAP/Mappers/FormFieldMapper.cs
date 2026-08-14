using Microsoft.Data.SqlClient;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class FormFieldMapper
    {
        public static FormField ToFormField(this FormFieldRequest request)
        {
            return new FormField
            {
                label = request.label,
                field = request.field,
                entityName = request.entityName,
                type = request.type,
                colSpan = request.colSpan,
                isDetail = request.isDetail,
                option = request.option,
                tabName = request.tabName,
                sortOrder = request.sortOrder,
                optionLabel = request.optionLabel,
                optionValue = request.optionValue,
                subField = request.subField,
                tagField = request.tagField,
                menuId = request.menuId
              
            };
        }

      
        public static void UpdateFormField(this FormField field, FormFieldRequest request)
        {
            field.label = request.label;
            field.field = request.field;
            field.entityName = request.entityName;
            field.type = request.type;
            field.colSpan = request.colSpan;
            field.isDetail = request.isDetail;
            field.option = request.option;
            field.tabName = request.tabName;
            field.sortOrder = request.sortOrder;
            field.optionLabel = request.optionLabel;
            field.optionValue = request.optionValue;
            field.subField = request.subField;
            field.tagField = request.tagField;
            field.menuId = request.menuId;
        }
    }
}