using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public class UsersRepository:IUsersRepository
    {
        private readonly BooDevContext _context;
        public UsersRepository(BooDevContext context)
        {
            _context = context;
        }
        public async Task<User> ValidateUsersRepository(string userName, string password)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return user;
        }
    }
}
