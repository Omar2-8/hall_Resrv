using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Roless
    {
        public Roless()
        {
            Logins = new HashSet<Login>();
        }

        public decimal RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
    }
}
