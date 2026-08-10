using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IActionRepository
    {
        Task<bool> ActionCodeExistsAsync(string code);
        Task<AppAction?> GetActionByIdAsync(int id);
        Task CreateActionAsync(AppAction action);
        Task UpdateActionAsync(AppAction action);
        Task DeleteActionAsync(AppAction action);
        Task<List<AppAction>> GetAllActionsFilteredAsync(ActionFilterRequest filter);
    }
}