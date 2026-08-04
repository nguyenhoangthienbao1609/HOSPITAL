using Microsoft.EntityFrameworkCore;
using THUCTAP.Interfaces;
using THUCTAP.Data;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Group> CreateGroupWithPermissionsAsync(CreateGroupRequest request)
        {
    
            var newGroup = new Group
            {
                name = request.group_name,
                code = request.group_code,
                menus = new List<Menu>(),     
                actions = new List<AppAction>() 
            };

            if (request.menuids.Any())
            {
                var menus = await _context.Menus.Where(m => request.menuids.Contains(m.id)).ToListAsync();
                foreach (var menu in menus)
                {
                    newGroup.menus.Add(menu);
                }
            }

            if (request.actionids.Any())
            {
                var actions = await _context.Actions.Where(a => request.actionids.Contains(a.id)).ToListAsync();
                foreach (var action in actions)
                {
                    newGroup.actions.Add(action);
                }
            }

            _context.Groups.Add(newGroup);
            await _context.SaveChangesAsync();

            return newGroup;
        }
    }
}