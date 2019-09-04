using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class User
    {
        public User()
        {
            UserMenuAccess = new HashSet<UserMenuAccess>();
            UserMenuAuthorization = new HashSet<UserMenuAuthorization>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserMenuAccess> UserMenuAccess { get; set; }
        public virtual ICollection<UserMenuAuthorization> UserMenuAuthorization { get; set; }
    }
}
