using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class FormFieldRepository : RepositoryBase<FormField>, IFormFieldRepository
    {
        private readonly AppDbContext _context;

        public FormFieldRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FormField> CreateFormFieldAsync(CustomFieldCreateRequest request)
        {
            
            var exists = await FindByCondition(f => f.field == request.fieldkey).AnyAsync();
            if (exists)
            {
                throw new Exception($"Field Key '{request.fieldkey}' đã tồn tại trong hệ thống.");
            }

            var newField = new FormField
            {
                label = request.label,
                field = request.fieldkey,

                
                entityname = "General", 
                type = "text",          
                colspan = 12,
                isdetail = false,
                createdat = DateTime.UtcNow,
                updatedat = DateTime.UtcNow
            };

            Create(newField);
            await _context.SaveChangesAsync();

            return newField;
        }
    }
}