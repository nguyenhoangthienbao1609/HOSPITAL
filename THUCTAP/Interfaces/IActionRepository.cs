using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IActionRepository
    {
        Task<AppAction> CreateActionAsync(ActionCreateRequest request);
    }
}