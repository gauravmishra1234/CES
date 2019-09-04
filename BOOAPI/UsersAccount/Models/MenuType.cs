using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class MenuType
    {
        public MenuType()
        {
            Menu = new HashSet<Menu>();
        }

        public int MenuTypeId { get; set; }
        public string MenuType1 { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}
