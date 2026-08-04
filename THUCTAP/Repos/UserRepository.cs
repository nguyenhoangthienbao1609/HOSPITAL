using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        // Khai báo _context riêng ở đây 
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public User? GetUserByCredentials(string username, string password)
        {
            return FindByCondition(u => u.username == username && u.password == password)
                .Include(u => u.groups) // <--- Cực kỳ quan trọng: Kéo theo cả danh sách nhóm quyền
                .FirstOrDefault();
        }

        public async Task<User> CreateUserAsync(UserCreateRequest request)
        {
            // 1. Kiểm tra xem usercode đã tồn tại chưa
            var exists = await _context.Users.AnyAsync(u => u.usercode == request.usercode);
            if (exists)
            {
                throw new Exception($"Mã nhân viên {request.usercode} đã tồn tại trong hệ thống.");
            }

            // 2. Map dữ liệu
            var newUser = new User
            {
                username = request.username,
                usercode = request.usercode,
                email = request.email,
                password = request.password,
                department = request.department,
                createdat = DateTime.UtcNow,
                updatedat = DateTime.UtcNow
            };

            // 3. Xử lý lưu quyền (Groups)
            if (request.groupids != null && request.groupids.Any())
            {
                var selectedGroups = await _context.Groups
                    .Where(g => request.groupids.Contains(g.id))
                    .ToListAsync();

                newUser.groups = selectedGroups;
            }

           
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
        public async Task<List<MenuResponseDto>> GetUserMenusAsync(int userId)
        {
            
            var userWithGroups = await _context.Users
                .Include(u => u.groups)
                    .ThenInclude(g => g.menus)
                .Include(u => u.groups)
                    .ThenInclude(g => g.actions)
                .FirstOrDefaultAsync(u => u.id == userId);

            if (userWithGroups == null) return new List<MenuResponseDto>();

            var allAllowedMenus = userWithGroups.groups
                .SelectMany(g => g.menus)
                .DistinctBy(m => m.id)
                .ToList();

            var allAllowedActions = userWithGroups.groups
                .SelectMany(g => g.actions)
                .DistinctBy(a => a.id)
                .ToList();

           
            var menuTree = new List<MenuResponseDto>();

          
            var parentMenus = allAllowedMenus.Where(m => m.parentid == null).OrderBy(m => m.id).ToList();

            foreach (var parent in parentMenus)
            {
                var parentDto = new MenuResponseDto
                {
                    id = parent.id,
                    label = parent.label,
                    to = parent.to,
                    icon = parent.icon,
                };

                // Lấy các Menu con thuộc về Menu cha này (nếu có)
                var childMenus = allAllowedMenus.Where(m => m.parentid == parent.id).OrderBy(m => m.id).ToList();
                foreach (var child in childMenus)
                {
                    var childDto = new MenuResponseDto
                    {
                        id = child.id,
                        label = child.label,
                        to = child.to,
                        icon = child.icon,
                        actions = allAllowedActions
                                    .Where(a => a.menuid == child.id)
                                    .Select(a => a.code)
                                    .ToList()
                    };
                    parentDto.children.Add(childDto);
                }

                menuTree.Add(parentDto);
            }

            return menuTree;
        }
        public async Task<List<UserResponseDto>> GetAllUsersWithPermissionsAsync()
        {
            // Lấy toàn bộ User, nối với Groups và nối tiếp với Actions
            return await _context.Users
                .Include(u => u.groups)
                    .ThenInclude(g => g.actions)
                .Select(u => new UserResponseDto
                {
                    id = u.id,
                    username = u.username,
                    usercode = u.usercode,
                    email = u.email,
                    department = u.department,

                    groups = u.groups.Select(g => g.name).ToList(),

                    permissions = u.groups
                                    .SelectMany(g => g.actions)
                                    .Select(a => a.label) 
                                    .Distinct()
                                    .ToList()
                })
                .ToListAsync();
        }
    }
}