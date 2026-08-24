using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using DocumentFormat.OpenXml.InkML;

namespace THUCTAP.Services
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;

        public MenuService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<MenuResponse>> GetFullMenuTreeAsync()
        {
            var allMenus = await _context.Menus.OrderBy(m => m.id).ToListAsync();
            var allActions = await _context.Actions.ToListAsync();

            var menuTree = new List<MenuResponse>();
            var parentMenus = allMenus.Where(m => m.parentId == null).ToList();

            foreach (var parent in parentMenus)
            {
                var parentDto = new MenuResponse
                {
                    id = parent.id,
                    label = parent.label,
                    to = parent.to,
                    icon = parent.icon,
                    children = new List<MenuResponse>()
                };

                var childMenus = allMenus.Where(m => m.parentId == parent.id).ToList();
                foreach (var child in childMenus)
                {
                    var childDto = new MenuResponse
                    {
                        id = child.id,
                        label = child.label,
                        to = child.to,
                        icon = child.icon,
                        action = allActions.Where(a => a.menuId == child.id).Select(a => a.code).ToList()
                    };
                    parentDto.children.Add(childDto);
                }
                menuTree.Add(parentDto);
            }

            return menuTree;
        }
        public async Task<MenuResponse> CreateDynamicMenuAsync(MenuCreateRequest request)
    {   
        var parentMenu = await _context.Menus
            .FirstOrDefaultAsync(m => m.label == request.parentMenuName);

        if (parentMenu == null)
        {
            parentMenu = new Menu { label = request.parentMenuName };
            _context.Menus.Add(parentMenu);
            await _context.SaveChangesAsync(); 
        }
            var createdChildren = new List<Menu>();
        if (request.childMenuName != null && request.childMenuName.Any())
        {
            foreach (var childName in request.childMenuName)
            {
                if (string.IsNullOrWhiteSpace(childName)) continue;

                var childMenu = await _context.Menus
                    .FirstOrDefaultAsync(m => m.label == childName && m.parentId == parentMenu.id);

                if (childMenu == null)
                {
                    childMenu = new Menu
                    {
                        label = childName,
                        parentId = parentMenu.id
                    };
                    _context.Menus.Add(childMenu);
                }

                createdChildren.Add(childMenu);
            }

            if (createdChildren.Any())
            {
                await _context.SaveChangesAsync();
            }
        }

        var response = MenuMapper.ToMenuResponseDto(parentMenu);

        foreach (var child in createdChildren)
        {
            response.children.Add(MenuMapper.ToMenuResponseDto(child));
        }

        return response;
    }
}
}