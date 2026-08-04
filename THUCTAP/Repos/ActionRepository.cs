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

        public async Task<AppAction> CreateActionAsync(ActionCreateRequest request)
        {
            // 1. Kiểm tra trùng lặp mã Action Code
            var exists = await FindByCondition(a => a.code == request.ActionCode).AnyAsync();
            if (exists)
            {
                throw new Exception($"Mã Action '{request.ActionCode}' đã tồn tại.");
            }

            var newAction = new AppAction
            {
                label = request.ActionName,
                code = request.ActionCode,
 
                menuid = 1,

                createdat = DateTime.UtcNow,
                updatedat = DateTime.UtcNow
            };

            // 3. Lưu xuống Database
            Create(newAction);
            await _context.SaveChangesAsync();

            return newAction;
        }
    }
}