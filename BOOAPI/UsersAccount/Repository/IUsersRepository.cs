using System.Collections.Generic;
using System.Threading.Tasks;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public interface IUsersRepository
    {
        Task<User> ValidateUsersRepository(string email, string password);
        Task<IEnumerable<User>> GetAllUsersRepository(int pageNum);
        Task<User> GetByUserIdRepository(int userId);
        Task<int> UpdateByUserIdRepository(User user);
        Task<int> InsertUserRepository(User user);
        Task<int> DeleteByIdUserRepository(int userId);
    }
}
