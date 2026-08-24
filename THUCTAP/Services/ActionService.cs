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

        public async Task<AppAction>CreateActionAsync(ActionCreateRequest request)
        {
            var exists = await _actionRepository.ActionCodeExistsAsync(request.actionCode, request.menuId);
            if (exists)
            {
                throw new Exception($"Mã Action '{request.actionCode}' đã tồn tại trong Menu này.");
            }

            var newAction = request.ToAppAction();

            await _actionRepository.CreateAsync(newAction);

            return newAction;
        }

        public async Task<AppAction>UpdateActionAsync(int id, UpdateActionRequest request)
        {
            var action = await _actionRepository.GetByIdAsync(id);
            if (action == null) return null;

            action.UpdateAppAction(request);

            await _actionRepository.UpdateAsync(action);

            return action;
        }

        public async Task<bool>DeleteActionAsync(int id)
        {
            var action = await _actionRepository.GetByIdAsync(id);
            if (action == null) return false;

            await _actionRepository.DeleteAsync(action);

            return true;
        }

        public async Task<PagedResult<ActionResponse>>GetAllActionsAsync(ActionFilterRequest filter)
        {
            return await _actionRepository.GetAllActionsAsync(filter);
        }
    }
}