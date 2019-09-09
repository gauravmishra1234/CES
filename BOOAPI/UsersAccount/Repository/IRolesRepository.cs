using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Role>> GetAllRolesRepository();
    }
}
