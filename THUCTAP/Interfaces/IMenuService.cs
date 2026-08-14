using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IMenuService
    {
       
        Task<List<MenuResponseDto>> GetFullMenuTreeAsync();
    }
}