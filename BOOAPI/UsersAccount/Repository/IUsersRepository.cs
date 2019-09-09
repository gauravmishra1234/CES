using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Dto;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public interface IUsersRepository
    {
        Task<UserDto> ValidateUsersRepository(string email, string password);
        Task<IEnumerable<User>> GetAllUsersRepository(int pageNum);
        Task<User> GetByUserIdRepository(int userId);
        Task<int> UpdateByUserIdRepository(User user);
        Task<int> InsertUserRepository(User user);
        Task<int> DeleteByIdUserRepository(int userId);
    }
}
