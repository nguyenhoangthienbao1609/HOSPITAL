using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class FormFieldRepository : IFormFieldRepository
    {
        private readonly AppDbContext _context;

        public FormFieldRepository(AppDbContext context)
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

        public async Task<PagedResult<FormFieldResponse>> GetAllFieldsAsync(FormFieldFilterRequest filter)
        {
            var query = _context.FormFields
                .Include(f => f.menu)
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.fieldKey))
                    query = query.Where(f => f.field.Contains(filter.fieldKey));
                if (!string.IsNullOrWhiteSpace(filter.type))
                    query = query.Where(f => f.type.Contains(filter.type));
            }

            var pagedRawFields = await query
                .AsNoTracking()
                .OrderByDescending(f => f.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawFields.Map(f => new FormFieldResponse
            {
                id = f.id,
                label = f.label,
                fieldKey = f.field,
                type = f.type,
                menuId = f.menuId ?? 0,
                menuName = f.menu != null ? f.menu.label : null
            });
        }

        // --- GỌI SAVECHANGES TRỰC TIẾP TẠI ĐÂY ---
        public async Task CreateFormFieldAsync(FormField field)
        {
            _context.FormFields.Add(field);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFormFieldAsync(FormField field)
        {
            _context.FormFields.Update(field);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFormFieldAsync(FormField field)
        {
            _context.FormFields.Remove(field);
            await _context.SaveChangesAsync();
        }
    }
}