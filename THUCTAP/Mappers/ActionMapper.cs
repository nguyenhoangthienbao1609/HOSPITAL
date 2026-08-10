using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class ActionMapper
    {
        
        public static AppAction ToAppAction(this ActionCreateRequest request)
        {
            return new AppAction
            {
                label = request.actionName,
                code = request.actionCode,
                menuId = 1, 
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateAppAction(this AppAction action, UpdateActionRequest request)
        {
            action.menuId = request.menuId;
            action.label = request.label;
            action.code = request.code;
            action.endpoint = request.endpoint;
            action.method = request.method;
            action.updatedAt = DateTime.UtcNow;
        }
    }
}