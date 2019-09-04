using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public interface IUsersRepository
    {
        Task<User> ValidateUsersRepository(string userName, string password);
    }
}
