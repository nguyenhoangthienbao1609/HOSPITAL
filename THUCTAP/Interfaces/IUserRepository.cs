using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    // Kế thừa IRepositoryBase 
    public interface IUserRepository
    {
        //  khai báo thêm các hàm đặc thù riêng của User ở đây
        User? GetUserByCredentials(string username, string password);
        Task<User> CreateUserAsync(UserCreateRequest request);
        Task<List<MenuResponseDto>> GetUserMenusAsync(int userId);
        Task<List<UserResponseDto>> GetAllUsersWithPermissionsAsync();

    }
}