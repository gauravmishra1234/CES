using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public class RolesRepository:IRolesRepository
    {
        private readonly BooDevContext _context;
        public RolesRepository(BooDevContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAllRolesRepository()
        {
            IEnumerable<Role> role = await _context.Role.ToListAsync();
            return role;
        }
    }
}
