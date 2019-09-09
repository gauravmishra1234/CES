using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersAccount.Dto;
using UsersAccount.Services;

namespace UsersAccount.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersServices _iUsersServices = null;
        public UsersController(IUsersServices iUsersServices)
        {
            _iUsersServices = iUsersServices;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> ValidateUser([FromBody] UserDto user)
        {
            try
            {
                UserDto userDto = await _iUsersServices.ValidateUsersServices(user.Email, user.Password);
                if (userDto == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                return userDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(int pageNum)
        {
            try
            {
                IEnumerable<UserDto> users = await _iUsersServices.GetAllUsersServices(pageNum);
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetByUserId(int userId)
        {
            try
            {
                UserDto user = await _iUsersServices.GetByUserIdServices(userId);

                if (user == null)
                {
                    return NotFound();
                }

                ////only allow admins to access other user records
                //var currentUserId = int.Parse(User.Identity.Name);
                //if (userId != currentUserId && !User.IsInRole("Admin"))
                //{
                //    return Forbid();
                //}

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<int> InsertUser([FromBody] UserDto userDto)
        {
            int result = 0;
            try
            {
                result = await _iUsersServices.InsertUserServices(userDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        [HttpPut]
        public async Task<int> UpdateByUserId([FromBody] UserDto userDto)
        {
            int result = 0;
            try
            {
                result = await _iUsersServices.UpdateByUserIdServices(userDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        [HttpDelete]
        public async Task<int> DeleteByIdUser(int userId)
        {
            int result = 0;
            try
            {
                result = await _iUsersServices.DeleteByIdServices(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
