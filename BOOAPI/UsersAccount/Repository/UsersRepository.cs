using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Dto;
using UsersAccount.Models;

namespace UsersAccount.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BooDevContext _context = null;
        public UsersRepository(BooDevContext context)
        {
            _context = context;
        }
        //public async Task<User> ValidateUsersRepository(string email, string password)
        //{
        //    User user = await _context.User.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        //    return user;
        //}
        public async Task<UserDto> ValidateUsersRepository(string email, string password)
        {

            try
            {  //var usertest = await (from u in _context.User
               //                      join r in _context.Role on u.RoleId equals r.RoleId
               //                      //into c_o from t in c_o.DefaultIfEmpty()
               //                      select new 
               //                      {
               //                          u.UserId,
               //                          u.UserName,
               //                          u.Password,
               //                          u.Email,
               //                          u.IsActive,
               //                          u.CreatedDate,
               //                          u.RoleId,
               //                          r.Role1
               //                      }).Where(x => x.Email == email).SingleOrDefaultAsync();

                UserDto userDto = await (from u in _context.User
                                         join r in _context.Role on u.RoleId equals r.RoleId
                                         select new UserDto()
                                         {
                                             UserId = u.UserId,
                                             UserName = u.UserName,
                                             Password = u.Password,
                                             Email = u.Email,
                                             IsActive = u.IsActive,
                                             CreatedDate = u.CreatedDate,
                                             RoleId = u.RoleId,
                                             Role = r.Role1
                                         }).Where(x => x.Email == email && x.Password == password).SingleOrDefaultAsync();


                //User user = await _context.User.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);

                //User user = await (from u in _context.User.Include(x => x.Role)
                //                   select u).Where(x => x.Email == email && x.Password == password).SingleOrDefaultAsync();
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<User>> GetAllUsersRepository(int pageNum)
        {
            try
            {
                IEnumerable<User> user = await _context.User.ToListAsync();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<User> GetByUserIdRepository(int userId)
        {
            try
            {
                User user = await _context.User.FindAsync(userId);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateByUserIdRepository(User user)
        {
            int result = 0;
            try
            {
                if (UserExists(user.UserId))
                {
                    _context.Entry(user).State = EntityState.Modified;
                    result = await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<int> InsertUserRepository(User user)
        {
            int result = 0;
            try
            {
                _context.User.Add(user);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<int> DeleteByIdUserRepository(int userId)
        {
            int result = 0;
            try
            {
                var user = await _context.User.FindAsync(userId);

                _context.User.Remove(user);
                result = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        private bool UserExists(int id)
        {
            bool isExists = false;
            try
            {
                if (id > 0)
                {
                    isExists = _context.User.Any(e => e.UserId == id);
                }
                return isExists;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
