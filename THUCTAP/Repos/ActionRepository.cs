using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class ActionRepository : RepositoryBase<AppAction>, IActionRepository
    {
        private readonly AppDbContext _context;

        public ActionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ActionCodeExistsAsync(string code)
        {
            return await _context.Actions.AnyAsync(a => a.code == code);
        }

        public async Task<AppAction?> GetActionByIdAsync(int id)
        {
            return await _context.Actions.FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task CreateActionAsync(AppAction action)
        {
            Create(action);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActionAsync(AppAction action)
        {
            Update(action); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActionAsync(AppAction action)
        {
            Delete(action); 
            await _context.SaveChangesAsync();
        }

        public async Task<List<AppAction>> GetAllActionsFilteredAsync(ActionFilterRequest filter)
        {
            var query = _context.Actions.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.label))
                    query = query.Where(a => a.label.Contains(filter.label));
                if (!string.IsNullOrWhiteSpace(filter.code))
                    query = query.Where(a => a.code.Contains(filter.code));
                if (!string.IsNullOrWhiteSpace(filter.endpoint))
                    query = query.Where(a => a.endpoint.Contains(filter.endpoint));
                if (!string.IsNullOrWhiteSpace(filter.method))
                    query = query.Where(a => a.method.Contains(filter.method));
            }

            return await query.ToListAsync();
        }
    }
}