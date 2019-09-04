using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParent = new HashSet<Menu>();
            RoleMenuAccess = new HashSet<RoleMenuAccess>();
            RoleMenuAuthorization = new HashSet<RoleMenuAuthorization>();
            UserMenuAccess = new HashSet<UserMenuAccess>();
            UserMenuAuthorization = new HashSet<UserMenuAuthorization>();
        }

        public int MenuId { get; set; }
        public int RootId { get; set; }
        public string MenuCode { get; set; }
        public string Menu1 { get; set; }
        public int MenuTypeId { get; set; }
        public int? ParentId { get; set; }
        public string TargetUrl { get; set; }
        public short SortOrder { get; set; }
        public bool? IsActive { get; set; }

        public virtual MenuType MenuType { get; set; }
        public virtual Menu Parent { get; set; }
        public virtual MenuRights MenuRights { get; set; }
        public virtual ICollection<Menu> InverseParent { get; set; }
        public virtual ICollection<RoleMenuAccess> RoleMenuAccess { get; set; }
        public virtual ICollection<RoleMenuAuthorization> RoleMenuAuthorization { get; set; }
        public virtual ICollection<UserMenuAccess> UserMenuAccess { get; set; }
        public virtual ICollection<UserMenuAuthorization> UserMenuAuthorization { get; set; }
    }
}
