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

        public async Task<bool> FieldKeyExistsAsync(string fieldKey)
        {
            return await _context.FormFields.AnyAsync(f => f.field == fieldKey);
        }

        public async Task<FormField?> GetFormFieldByIdAsync(int id)
        {
            return await _context.FormFields.FirstOrDefaultAsync(f => f.id == id);
        }

        public async Task CreateFormFieldAsync(FormField field)
        {
            Create(field);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFormFieldAsync(FormField field)
        {
            Update(field); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFormFieldAsync(FormField field)
        {
            Delete(field); 
            await _context.SaveChangesAsync();
        }

        public async Task<List<FormField>> GetAllFieldsFilteredAsync(FormFieldFilterRequest filter)
        {
            var query = _context.FormFields.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.label))
                    query = query.Where(f => f.label.Contains(filter.label));

                if (!string.IsNullOrWhiteSpace(filter.fieldKey))
                    query = query.Where(f => f.field.Contains(filter.fieldKey));

                if (!string.IsNullOrWhiteSpace(filter.entityName))
                    query = query.Where(f => f.entityName.Contains(filter.entityName));

                if (!string.IsNullOrWhiteSpace(filter.type))
                    query = query.Where(f => f.type.Contains(filter.type));
            }

            return await query.ToListAsync();
        }
    }
}