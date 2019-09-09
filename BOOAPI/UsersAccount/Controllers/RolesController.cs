using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersAccount.Services;
using UsersAccount.Dto;

namespace UsersAccount.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRolesServices _iRolesServices;

        public RolesController(IRolesServices iRolesServices)
        {
            _iRolesServices = iRolesServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles()
        {
            IEnumerable<RoleDto> roles = await _iRolesServices.GetAllRolesServices();
            return Ok(roles);
        }
    }
}
