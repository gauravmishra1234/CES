using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Dto;


namespace UsersAccount.Services
{
    public interface IUsersServices
    {
        Task<UserDto> ValidateUsersServices(string email, string password);
        Task<IEnumerable<UserDto>> GetAllUsersServices(int pageNum);
        Task<UserDto> GetByUserIdServices(int userId);
        Task<int> UpdateByUserIdServices(UserDto userDto);
        Task<int> InsertUserServices(UserDto userDto);
        Task<int> DeleteByIdServices(int userId);
        Task<UserDto> ValidateEmailServices(string email);
    }
}
