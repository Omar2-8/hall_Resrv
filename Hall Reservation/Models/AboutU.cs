using System;
using System.Collections.Generic;

namespace Hall_Reservation.Models
{
    public partial class AboutU
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public decimal? HomeId { get; set; }

        public virtual Home? Home { get; set; }
    }
}
