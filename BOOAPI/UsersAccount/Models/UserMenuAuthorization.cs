using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class UserMenuAuthorization
    {
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public bool? AddRight { get; set; }
        public bool? EditRight { get; set; }
        public bool? ActiveRight { get; set; }
        public bool? PrintRight { get; set; }
        public bool? CustomRight { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
    }
}
