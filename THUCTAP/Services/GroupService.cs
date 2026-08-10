using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly AppDbContext _context;

        public GroupService(IGroupRepository groupRepository, AppDbContext context)
        {
            _groupRepository = groupRepository;
            _context = context;
        }

        public async Task<Group> CreateGroupAsync(CreateGroupRequest request)
        {
         
            var group = new Group
            {
                name = request.groupName,
                code = request.groupCode
            };

            var explicitMenuIds = request.permission != null
                ? request.permission.Select(p => p.menuId).Distinct().ToList()
                : new List<int>();

            var explicitActionIds = request.permission != null
                ? request.permission.SelectMany(p => p.action).Select(a => a.actionId).Distinct().ToList()
                : new List<int>();

            var menuIdsFromActions = await _groupRepository.GetMenuIdsFromActionsAsync(explicitActionIds);
            var allExplicitMenuIds = explicitMenuIds.Union(menuIdsFromActions).Distinct().ToList();
            var parentMenuIds = await _groupRepository.GetParentMenuIdsAsync(allExplicitMenuIds);
            var finalMenuIds = allExplicitMenuIds.Union(parentMenuIds).Distinct().ToList();

            group.menu = await _groupRepository.GetMenusByIdsAsync(finalMenuIds);

            group.action = await _groupRepository.GetActionsByIdsAsync(explicitActionIds);

            await _groupRepository.CreateGroupAsync(group);

            return group;
        }

        public async Task<Group> UpdateGroupAsync(int id, CreateGroupRequest request)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null) throw new Exception("Không tìm thấy nhóm quyền!");

            group.name = request.groupName;
            group.code = request.groupCode;

            var explicitMenuIds = request.permission != null
                ? request.permission.Select(p => p.menuId).Distinct().ToList()
                : new List<int>();

            var explicitActionIds = request.permission != null
                ? request.permission.SelectMany(p => p.action).Select(a => a.actionId).Distinct().ToList()
                : new List<int>();

            var menuIdsFromActions = await _groupRepository.GetMenuIdsFromActionsAsync(explicitActionIds);
            var allExplicitMenuIds = explicitMenuIds.Union(menuIdsFromActions).Distinct().ToList();
            var parentMenuIds = await _groupRepository.GetParentMenuIdsAsync(allExplicitMenuIds);
            var finalMenuIds = allExplicitMenuIds.Union(parentMenuIds).Distinct().ToList();

            group.menu = await _groupRepository.GetMenusByIdsAsync(finalMenuIds);

            // 4. XỬ LÝ ACTION (Nghiêm ngặt: Chỉ lấy đúng action Frontend truyền lên)
            group.action = await _groupRepository.GetActionsByIdsAsync(explicitActionIds);

            // 5. LƯU VÀO DATABASE
            await _groupRepository.UpdateGroupAsync(group);

            // Trả về group để giải quyết lỗi CS0161
            return group;
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null) return false;

            await _groupRepository.DeleteGroupAsync(group);
            return true;
        }

        public async Task<List<GroupResponse>> GetAllGroupsAsync(GroupFilterRequest filter)
        {
            return await _groupRepository.GetAllGroupsAsync(filter);
        }


        //private async Task ResolveGroupPermissionsAsync(Group group, List<PermissionDto> permission)
        //{
        //    if (permission == null || !permission.Any()) return;

        //    var explicitMenuIds = permission.Select(p => p.menuId).Distinct().ToList();
        //    var explicitActionIds = permission.Where(p => p.action != null)
        //                                       .SelectMany(p => p.action.Select(a => a.actionId))
        //                                       .Distinct().ToList();

        //    // Sử dụng các hàm phụ trợ từ Repo để lấy dữ liệu
        //    var childMenus = await _groupRepository.GetChildMenuIdsAsync(explicitMenuIds);
        //    var autoActionIds = await _groupRepository.GetAutoActionIdsAsync(childMenus);
        //    var menuIdsFromActions = await _groupRepository.GetMenuIdsFromActionsAsync(explicitActionIds);

        //    var allMenuIds = explicitMenuIds.Union(childMenus).Union(menuIdsFromActions).Distinct().ToList();
        //    var parentMenuIds = await _groupRepository.GetParentMenuIdsAsync(allMenuIds);

        //    var finalMenuIds = allMenuIds.Union(parentMenuIds).Distinct().ToList();
        //    var finalActionIds = explicitActionIds.Union(autoActionIds).Distinct().ToList();

        //    // Gán dữ liệu thật vào entity Group
        //    group.menu = await _groupRepository.GetMenusByIdsAsync(finalMenuIds);
        //    group.action = await _groupRepository.GetActionsByIdsAsync(finalActionIds);
        //}
        public async Task<List<MenuMatrixDto>> GetGroupPermissionMatrixAsync(int groupId)
        {
            // 1. Luôn kéo toàn bộ Menu và Action thô lên làm "khung xương"
            var allMenus = await _context.Menus.AsNoTracking().ToListAsync();
            var allActions = await _context.Actions.AsNoTracking().ToListAsync();

            // 2. Khai báo biến group = null (Mặc định cho kịch bản Tạo mới)
            Group? group = null;

            // Kịch bản Cập nhật: Chỉ chọc xuống DB lấy Group nếu groupId > 0
            if (groupId > 0)
            {
                group = await _context.Groups
                    .Include(g => g.menu)
                    .Include(g => g.action)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(g => g.id == groupId);

                if (group == null) throw new Exception("Không tìm thấy Nhóm quyền này!");
            }

            // 3. Build Cây Ma trận (Kết hợp Full Menu và biến group)
            var matrixTree = new List<MenuMatrixDto>();
            var parentMenus = allMenus.Where(m => m.parentId == null).ToList();

            foreach (var parent in parentMenus)
            {
                var parentDto = new MenuMatrixDto
                {
                    id = parent.id,
                    label = parent.label,
                    icon = parent.icon,

                    // Xử lý isGranted: Nếu group tồn tại VÀ chứa menu này thì True, ngược lại là False
                    isGranted = group != null && group.menu.Any(m => m.id == parent.id),
                    children = new List<MenuMatrixDto>(),

                    action = allActions.Where(a => a.menuId == parent.id).Select(a => new ActionMatrixDto
                    {
                        id = a.id,
                        label = a.label,
                        code = a.code,
                        // Tương tự cho Action
                        isGranted = group != null && group.action.Any(ga => ga.id == a.id)
                    }).ToList()
                };

                var childMenus = allMenus.Where(m => m.parentId == parent.id).ToList();
                foreach (var child in childMenus)
                {
                    var childDto = new MenuMatrixDto
                    {
                        id = child.id,
                        label = child.label,
                        icon = child.icon,
                        isGranted = group != null && group.menu.Any(m => m.id == child.id),
                        action = allActions.Where(a => a.menuId == child.id).Select(a => new ActionMatrixDto
                        {
                            id = a.id,
                            label = a.label,
                            code = a.code,
                            isGranted = group != null && group.action.Any(ga => ga.id == a.id)
                        }).ToList()
                    };
                    parentDto.children.Add(childDto);
                }
                matrixTree.Add(parentDto);
            }

            return matrixTree;
        }
    }
}