using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuResponse>>GetFullMenuTreeAsync();
        Task<MenuResponse> CreateDynamicMenuAsync(MenuCreateRequest request);
    }
}