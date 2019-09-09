using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAccount.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }

        // Extra Property only for Dto
        public string Token { get; set; }
        //public RoleDto Role { get; set; }
        public string Role { get; set; }
    }
}
