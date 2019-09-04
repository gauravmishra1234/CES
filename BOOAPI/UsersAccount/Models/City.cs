using System;
using System.Collections.Generic;

namespace UsersAccount.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string City1 { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
