using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> CreateGroupWithPermissionsAsync(CreateGroupRequest request);
    }
}