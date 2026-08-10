using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuResponseDto>> GetFullMenuTreeAsync()
        {
            // Lấy toàn bộ Menu và Action trong hệ thống
            var allMenus = await _context.Menus.OrderBy(m => m.id).ToListAsync();
            var allActions = await _context.Actions.ToListAsync();

            var menuTree = new List<MenuResponseDto>();
            var parentMenus = allMenus.Where(m => m.parentId == null).ToList();

            // Xây dựng cây phân cấp (Tree)
            foreach (var parent in parentMenus)
            {
                var parentDto = new MenuResponseDto
                {
                    id = parent.id,
                    label = parent.label,
                    to = parent.to,
                    icon = parent.icon,
                    children = new List<MenuResponseDto>()
                };

                var childMenus = allMenus.Where(m => m.parentId == parent.id).ToList();
                foreach (var child in childMenus)
                {
                    var childDto = new MenuResponseDto
                    {
                        id = child.id,
                        label = child.label,
                        to = child.to,
                        icon = child.icon,
                        // Gom tất cả các Action thuộc về Menu con này
                        action = allActions.Where(a => a.menuId == child.id).Select(a => a.code).ToList()
                    };
                    parentDto.children.Add(childDto);
                }
                menuTree.Add(parentDto);
            }

            return menuTree;
        }
    }
}