using THUCTAP.Models;

namespace THUCTAP.Interfaces
{
    // Kế thừa IRepositoryBase 
    public interface IUserRepository : IRepositoryBase<User>
    {
        //  khai báo thêm các hàm đặc thù riêng của User ở đây
        User? GetUserByCredentials(string username, string password);
    }
}