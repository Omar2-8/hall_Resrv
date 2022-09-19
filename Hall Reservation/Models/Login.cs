using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class Login
    {
        public decimal LoginId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal? UserId { get; set; }
        public decimal? RolesId { get; set; }

        public virtual Roless? Roles { get; set; }
        public virtual User? User { get; set; }
    }
}
