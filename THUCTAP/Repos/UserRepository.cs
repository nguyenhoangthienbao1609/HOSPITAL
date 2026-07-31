using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;

namespace THUCTAP.Repos
{
    // Kế thừa RepositoryBase và IUserRepository
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public User? GetUserByCredentials(string username, string password)
        {
            return FindByCondition(u => u.username == username && u.password == password).FirstOrDefault();
        }
    }
}