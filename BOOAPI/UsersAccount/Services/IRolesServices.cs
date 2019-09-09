using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Dto;

namespace UsersAccount.Services
{
    public interface IRolesServices
    {
        Task<IEnumerable<RoleDto>> GetAllRolesServices();
    }
}
