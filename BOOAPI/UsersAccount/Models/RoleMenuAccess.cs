using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class RoleMenuAccess
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool IsAccessible { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Role Role { get; set; }
    }
}
