using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class DepView
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Salary { get; set; }
    }
}
