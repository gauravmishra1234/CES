using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class UserMenuAccess
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public bool IsAccessible { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
    }
}
