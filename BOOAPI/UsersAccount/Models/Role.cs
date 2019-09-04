using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMenuAccess = new HashSet<RoleMenuAccess>();
            RoleMenuAuthorization = new HashSet<RoleMenuAuthorization>();
            User = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Role1 { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<RoleMenuAccess> RoleMenuAccess { get; set; }
        public virtual ICollection<RoleMenuAuthorization> RoleMenuAuthorization { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
