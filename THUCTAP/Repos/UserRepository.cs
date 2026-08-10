using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Extensions;

namespace THUCTAP.Repos
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public User? GetUserByCredentials(string username, string password)
        {
            return FindByCondition(u => u.userName == username && u.password == password)
                .Include(u => u.group).ThenInclude(g => g.menu).ThenInclude(m => m.parent)
                .Include(u => u.group).ThenInclude(g => g.action)
                .FirstOrDefault();
        }

        public async Task<bool> UserCodeExistsAsync(string userCode) =>
            await _context.Users.AnyAsync(u => u.userCode == userCode);

        public async Task<User?> GetUserByIdWithGroupsAsync(int id) =>
            await _context.Users.Include(u => u.group).FirstOrDefaultAsync(u => u.id == id);

        public async Task<User?> GetUserWithFullPermissionsAsync(int userId) =>
            await _context.Users
                .Include(u => u.group).ThenInclude(g => g.menu)
                .Include(u => u.group).ThenInclude(g => g.action)
                .FirstOrDefaultAsync(u => u.id == userId);

        public async Task<List<Group>> GetGroupsByIdsAsync(List<int> groupIds) =>
            await _context.Groups.Where(g => groupIds.Contains(g.id)).ToListAsync();

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserResponseDto>> GetAllUsersWithPermissionsAsync()
        {
            var rawUsers = await _context.Users
                .Include(u => u.group).ThenInclude(g => g.action)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

            return rawUsers.Select(u => new UserResponseDto
            {
                id = u.id,
                userName = u.userName,
                userCode = u.userCode,
                email = u.email,
                department = u.department,
                group = u.group.Select(g => g.name).ToList(),
                permission = u.group.SelectMany(g => g.action).Select(a => a.label).Distinct().ToList()
            }).ToList();
        }

        public async Task<PagedResult<UserResponseDto>> GetAllUsersAsync(UserFilterRequest filter)
        {
            var query = _context.Users.Include(u => u.group).AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.userName)) query = query.Where(u => u.userName.Contains(filter.userName));
                if (!string.IsNullOrWhiteSpace(filter.userCode)) query = query.Where(u => u.userCode.Contains(filter.userCode));
                if (!string.IsNullOrWhiteSpace(filter.email)) query = query.Where(u => u.email.Contains(filter.email));
                if (!string.IsNullOrWhiteSpace(filter.department)) query = query.Where(u => u.department.Contains(filter.department));
                if (!string.IsNullOrWhiteSpace(filter.userGroup))
                    query = query.Where(u => u.group.Any(g => g.name.Contains(filter.userGroup) || g.code.Contains(filter.userGroup)));
            }

            var rawUsers = await query
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
            var pagedRawUsers = await query
            .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawUsers.Map(u => new UserResponseDto
            {
                id = u.id,
                userName = u.userName,
                userCode = u.userCode,
                email = u.email,
                department = u.department,
                group = u.group.Select(g => g.name).ToList()
            });
        }
    }
}