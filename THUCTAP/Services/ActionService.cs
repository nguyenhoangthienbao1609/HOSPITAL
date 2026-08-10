using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;

      
        public ActionService(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public async Task<AppAction> CreateActionAsync(ActionCreateRequest request)
        {
            
            var exists = await _actionRepository.ActionCodeExistsAsync(request.actionCode);
            if (exists)
            {
                throw new Exception($"Mã Action '{request.actionCode}' đã tồn tại.");
            }

            var newAction = request.ToAppAction();

            await _actionRepository.CreateActionAsync(newAction);

            return newAction;
        }

        public async Task<AppAction> UpdateActionAsync(int id, UpdateActionRequest request)
        {
            // 1. Tìm dữ liệu
            var action = await _actionRepository.GetActionByIdAsync(id);
            if (action == null) return null;

            // 2. Map dữ liệu mới vào Entity cũ
            action.UpdateAppAction(request);

            // 3. Lưu xuống DB
            await _actionRepository.UpdateActionAsync(action);
            return action;
        }

        public async Task<bool> DeleteActionAsync(int id)
        {
            var action = await _actionRepository.GetActionByIdAsync(id);
            if (action == null) return false;

            await _actionRepository.DeleteActionAsync(action);
            return true;
        }

        public async Task<List<AppAction>> GetAllActionsAsync(ActionFilterRequest filter)
        {
            // Logic lọc có liên quan mật thiết tới IQueryable nên ta để Repo xử lý, Service chỉ gọi lại.
            return await _actionRepository.GetAllActionsFilteredAsync(filter);
        }
    }
}