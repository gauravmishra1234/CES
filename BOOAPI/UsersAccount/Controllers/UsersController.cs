using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAccount.Dto;
using UsersAccount.Services;
using UsersAccount.Models;

namespace UsersAccount.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersServices _iUsersServices;
        public UsersController(IUsersServices iUsersServices)
        {
            _iUsersServices = iUsersServices;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> ValidateUser([FromBody] UserDto user)
        {
            var userDto = await _iUsersServices.ValidateUsersServices(user.UserName, user.Password);
            return userDto;
        }
    }
}
